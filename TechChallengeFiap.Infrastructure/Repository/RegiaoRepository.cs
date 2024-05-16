using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Infrastructure.Contexto;
using TechChallengeFiap.Infrastructure.Interface;

namespace TechChallengeFiap.Infrastructure.Repository
{
    public class RegiaoRepository : BaseRepository<Regiao>, IRegiaoRepository
    {
        public RegiaoRepository(ApplicationDbContexto context) : base(context)
        {}
    }
}
