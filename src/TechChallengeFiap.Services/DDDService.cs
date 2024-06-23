using TechChallengeFiap.Domain.Interfaces.Repository;
using TechChallengeFiap.Domain.Interfaces.Service;
using TechChallengeFiap.Domain.Models.DDDs;
using TechChallengeFiap.Domain.Models.Estados;

namespace TechChallengeFiap.Services
{
    public class DDDService : IDDDService
    {
        private readonly IEstadoRepository _estadoRepository;

        /// <summary>
        /// Construtor do método
        /// </summary>
        /// <param name="estadoRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DDDService(IEstadoRepository estadoRepository)
            => _estadoRepository = estadoRepository ?? throw new ArgumentNullException(nameof(estadoRepository));

        /// <summary>
        /// Busca todos os DDD's
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EstadoDDDViewModel>> BuscarTodos()
            => (await _estadoRepository.BuscarEstadosDDDs()).Select(x => new EstadoDDDViewModel
            {
                Descricao = x.Descricao,
                DDDs = x.DDDs.Select(y => new DDDViewModel
                {
                    Id = y.Id,
                    NumeroDDD = y.NumeroDDD,
                    Regioes = y.Regioes
                }).OrderBy(z => z.NumeroDDD)
            }).OrderBy(x => x.Descricao);
    }
}
