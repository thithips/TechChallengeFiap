using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces.Repository;
using TechChallengeFiap.Infrastructure.Contexto;

namespace TechChallengeFiap.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContexto _context;
        protected DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContexto context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public virtual void Alterar(T entity) => _dbSet.Update(entity);

        public async Task<T> Buscar(Expression<Func<T, bool>> predicate)
            => await _dbSet.FirstOrDefaultAsync(predicate);

        public virtual async Task<List<T>> BuscarVarios(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public virtual void Incluir(T entity)
        {
            entity.DataCriacao = DateTime.Now;
            _dbSet.Add(entity);
        }

        public virtual void Remover(T entity) => _dbSet.Remove(entity);

        public virtual async Task<T> SelecionarPorId(Guid id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task<List<T>> SelecionarTudo()
            => await _dbSet.ToListAsync();

        public void Dispose() => _context.Dispose();

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();
    }
}
