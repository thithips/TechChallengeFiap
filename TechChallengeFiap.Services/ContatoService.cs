﻿using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces.Repository;
using TechChallengeFiap.Domain.Interfaces.Service;
using TechChallengeFiap.Domain.Models.Contatos;

namespace TechChallengeFiap.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _repository;
        private readonly IDDDRepository _dddRepository;

        public ContatoService(IContatoRepository repo, IDDDRepository dddRepository)
        {
            _repository = repo;
            _dddRepository = dddRepository;
        }

        public async Task<IEnumerable<ContatoViewModel>> BuscarTodos()
        {
            var entities = await _repository.SelecionarTudo();
            return entities.Select(x => new ContatoViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Nome = x.Nome,
                Telefone = x.DDD.NumeroDDD + x.Telefone
            });
        }

        public async Task<ContatoViewModel> BuscarPorId(Guid id)
        {
            var entity = await _repository.SelecionarPorId(id);
            return new ContatoViewModel { Id = entity.Id, Email = entity.Email, Nome = entity.Nome, Telefone = entity.DDD.NumeroDDD + entity.Telefone };
        }

        public async Task<IEnumerable<ContatoViewModel>> BuscarPorDDD(Guid idDDD)
        {
            var entities = await _repository.BuscarVarios(x => x.IdDDD == idDDD);
            return entities.Select(x => new ContatoViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Nome = x.Nome,
                Telefone = x.DDD.NumeroDDD + x.Telefone
            });
        }

        public async Task<IEnumerable<ContatoViewModel>> BuscarPorRegiao(Guid idRegiao)
        {
            var entities = await _repository.BuscarVarios(x => x.DDD.Estado.Regiao.Id == idRegiao);
            return entities.Select(x => new ContatoViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Nome = x.Nome,
                Telefone = x.DDD.NumeroDDD + x.Telefone
            });
        }

        public async Task Cadastrar(ContatoInputModel model)
        {
            var ddd = await _dddRepository.Buscar(x => x.NumeroDDD == int.Parse(model.Telefone.Substring(0, 2)));

            Contato entity = new(model.Nome, model.Email, model.Telefone.Substring(2), ddd);

            await _repository.Incluir(entity);
        }

        public async Task Alterar(ContatoUpdateInputModel model)
        {
            var entity = await _repository.SelecionarPorId(model.Id);
            var modelDDD = int.Parse(model.Telefone.Substring(0, 2));

            if (entity.DDD.NumeroDDD != modelDDD)
            {
                var ddd = await _dddRepository.Buscar(x => x.NumeroDDD == int.Parse(model.Telefone.Substring(0, 2)));
                entity.AlterarTelefone(ddd, model.Telefone.Substring(2));
            }

            entity.Alterar(model.Nome, model.Email, model.Telefone.Substring(2), entity.DDD);

            await _repository.Alterar(entity);
        }

        public async Task Deletar(Guid id)
        {
            var entity = await _repository.SelecionarPorId(id);
            await _repository.Remover(entity);
        }
    }
}
