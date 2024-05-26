using TechChallengeFiap.Domain.Interfaces.Repository;
using TechChallengeFiap.Domain.Interfaces.Service;
using TechChallengeFiap.Domain.Models.Regiao;

namespace TechChallengeFiap.Services
{
    public class RegiaoService : IRegiaoService
    {
        private readonly IRegiaoRepository _regiaoRepository;

        public RegiaoService(IRegiaoRepository regiaoRepository)
        {
            _regiaoRepository = regiaoRepository ?? throw new ArgumentNullException(nameof(regiaoRepository));
        }

        public async Task<IEnumerable<RegiaoViewModel>> BuscarTodos()
            => (await _regiaoRepository.SelecionarTudo()).Select(x => new RegiaoViewModel
            {
                Id = x.Id,
                Descricao = x.Descricao
            }).OrderBy(x => x.Descricao);
    }
}
