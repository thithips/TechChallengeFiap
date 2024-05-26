using Microsoft.EntityFrameworkCore;
using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces.Repository;
using TechChallengeFiap.Infrastructure.Contexto;

namespace TechChallengeFiap.Infrastructure.Repository
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(ApplicationDbContexto context) : base(context)
        {}

        public async Task<IEnumerable<Estado>> BuscarEstadosDDDs()
            => await _dbSet.Include(x => x.DDDs).ToListAsync();
    }
}
