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

        public async Task Alterar(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Buscar(Expression<Func<T, bool>> predicate)
            =>  await _dbSet.FirstOrDefaultAsync(predicate);
        
        

        public virtual async Task<List<T>> BuscarVarios(Expression<Func<T, bool>> predicate) 
            => await _dbSet.Where(predicate).ToListAsync();

        public async Task Incluir(T entity)
        {
            entity.DataCriacao = DateTime.Now;
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> SelecionarPorId(Guid id) 
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        
        public virtual async Task<List<T>> SelecionarTudo() 
            => await _dbSet.ToListAsync();
    }
}
