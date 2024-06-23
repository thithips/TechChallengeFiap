using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces.Repository;
using TechChallengeFiap.Infrastructure.Contexto;

namespace TechChallengeFiap.Infrastructure.Repository
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(ApplicationDbContexto context) : base(context)
        { }
        /// <summary>
        /// Busca todos os contatos
        /// </summary>
        /// <returns></returns>
        public override async Task<List<Contato>> SelecionarTudo()
            => await _dbSet.Include(x => x.DDD).ToListAsync();

        /// <summary>
        /// Busca um contato por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<Contato> SelecionarPorId(Guid id)
            => await _dbSet.Include(x => x.DDD).FirstOrDefaultAsync(x => x.Id == id);

        /// <summary>
        /// Busca vários contatos a partir de uma expressão
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public override async Task<List<Contato>> BuscarVarios(Expression<Func<Contato, bool>> predicate)
            => await _dbSet.Include(x => x.DDD).Where(predicate).ToListAsync();
    }
}
