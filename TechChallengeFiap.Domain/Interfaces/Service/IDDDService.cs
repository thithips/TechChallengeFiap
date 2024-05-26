using TechChallengeFiap.Domain.Models.Estados;

namespace TechChallengeFiap.Domain.Interfaces.Service
{
    public interface IDDDService
    {
        Task<IEnumerable<EstadoDDDViewModel>> BuscarTodos();
    }
}