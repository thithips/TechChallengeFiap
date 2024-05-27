using TechChallengeFiap.Domain.Models.Regiao;

namespace TechChallengeFiap.Domain.Interfaces.Service
{
    public interface IRegiaoService
    {
        Task<IEnumerable<RegiaoViewModel>> BuscarTodos();
    }
}