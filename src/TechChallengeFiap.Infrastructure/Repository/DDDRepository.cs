using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Interfaces.Repository;
using TechChallengeFiap.Infrastructure.Contexto;

namespace TechChallengeFiap.Infrastructure.Repository
{
    public class DDDRepository : BaseRepository<DDD>, IDDDRepository
    {
        public DDDRepository(ApplicationDbContexto context) : base(context)
        {}
    }
}
