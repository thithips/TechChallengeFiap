using TechChallengeFiap.Core;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces.Repository;
using TechChallengeFiap.Domain.Interfaces.Service;
using TechChallengeFiap.Domain.Models.Contatos;

namespace TechChallengeFiap.Services
{
    public class ContatoService : BaseService, IContatoService
    {
        private readonly IContatoRepository _repository;
        private readonly IDDDRepository _dddRepository;
        private IRabbitMQMessageSender _messageSender;

        /// <summary>
        /// Construtor do metodo
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="dddRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ContatoService(IContatoRepository repo, IDDDRepository dddRepository, IRabbitMQMessageSender messageSender, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repository = repo ?? throw new ArgumentNullException(nameof(repo));
            _dddRepository = dddRepository ?? throw new ArgumentNullException(nameof(dddRepository));
            _messageSender = messageSender;
        }

        /// <summary>
        /// Busca todos os contatos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ContatoViewModel>> BuscarTodos()
        {
            var entities = await _repository.SelecionarTudo();
            return entities.Select(x => new ContatoViewModel
            {
                Id = x.Id,
                Email = x.Email.Endereco,
                Nome = x.Nome,
                Telefone = x.DDD!.NumeroDDD + x.Telefone
            });
        }

        /// <summary>
        /// Busca um contato especifico por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ContatoViewModel> BuscarPorId(Guid id)
        {
            var entity = await _repository.SelecionarPorId(id);
            return new ContatoViewModel { Id = entity.Id, Email = entity.Email.Endereco, Nome = entity.Nome, Telefone = entity.DDD!.NumeroDDD + entity.Telefone };
        }

        /// <summary>
        /// Busca varios contatos por DDD 
        /// </summary>
        /// <param name="idDDD"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContatoViewModel>> BuscarPorDDD(Guid idDDD)
        {
            var entities = await _repository.BuscarVarios(x => x.IdDDD == idDDD);
            return entities.Select(x => new ContatoViewModel
            {
                Id = x.Id,
                Email = x.Email.Endereco,
                Nome = x.Nome,
                Telefone = x.DDD!.NumeroDDD + x.Telefone
            });
        }

        /// <summary>
        /// Busca varios contatos por regiao
        /// </summary>
        /// <param name="idRegiao"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContatoViewModel>> BuscarPorRegiao(Guid idRegiao)
        {
            var entities = await _repository.BuscarVarios(x => x.DDD!.Estado!.Regiao!.Id == idRegiao);
            return entities.Select(x => new ContatoViewModel
            {
                Id = x.Id,
                Email = x.Email.Endereco,
                Nome = x.Nome,
                Telefone = x.DDD!.NumeroDDD + x.Telefone
            });
        }

        /// <summary>
        /// Cadastra um novo contato
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Cadastrar(ContatoInputModel model)
        {
            var ddd = await _dddRepository.Buscar(x => x.NumeroDDD == int.Parse(model.Telefone.Substring(0, 2)));

            Contato entity = new(model.Nome, model.Email, model.Telefone.Substring(2), ddd);

             _repository.Incluir(entity);
            
            if(!await Commit()) return;

            var emailMessage = new EmailModel
            {
                Email = model.Email,
                Subject = "Bem-vindo",
                Message = $"Olá {model.Nome}, seja bem-vindo!"
            };

            _messageSender.SendMessage(emailMessage);
        }

        /// <summary>
        /// Altera um contato a partir do ID especificado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

             _repository.Alterar(entity);
            await Commit();
        }

        /// <summary>
        /// Deleta um contato a partir do ID especificado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Deletar(Guid id)
        {
            var entity = await _repository.SelecionarPorId(id);
             _repository.Remover(entity);
            await Commit();
        }
    }
}
