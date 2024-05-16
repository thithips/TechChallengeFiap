using TechChallengeFiap.Infrastructure.Interface;
using TechChallengeFiap.Infrastructure.Repository;

namespace TechChallengeFiap.Services
{
    public class RegiaoService
    {
        private readonly IRegiaoRepository _repo;

        public RegiaoService(RegiaoRepository repo)
        {
            _repo = repo;
        }
    }
}
