using System.Linq.Expressions;
using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Incluir(T entity);
        Task Alterar(T entity);
        Task<T> SelecionarPorId(Guid id);
        Task<List<T>> SelecionarTudo();
        Task<T> Buscar(Expression<Func<T, bool>> predicate);
        Task<List<T>> BuscarVarios(Expression<Func<T, bool>> predicate);
        Task Remover(T entity);
    }
}
