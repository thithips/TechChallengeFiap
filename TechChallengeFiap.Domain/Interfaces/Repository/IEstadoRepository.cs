using TechChallengeFiap.Domain.Entities;

namespace TechChallengeFiap.Domain.Interfaces.Repository
{
    public interface IEstadoRepository : IBaseRepository<Estado>
    {
        Task<IEnumerable<Estado>> BuscarEstadosDDDs();
    }
}
