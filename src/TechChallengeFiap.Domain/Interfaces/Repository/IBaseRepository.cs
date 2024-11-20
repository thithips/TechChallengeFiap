﻿using System.Linq.Expressions;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task<List<T>> SelecionarTudo();
        Task<T> Buscar(Expression<Func<T, bool>> predicate);
        Task<List<T>> BuscarVarios(Expression<Func<T, bool>> predicate);
        Task<T> SelecionarPorId(Guid id);

        void Incluir(T entity);
        void Alterar(T entity);
        void Remover(T entity);

        Task<int> SaveChanges();
    }
}