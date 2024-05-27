using TechChallengeFiap.Domain.Models.Contatos;

namespace TechChallengeFiap.Domain.Interfaces.Service
{
    public interface IContatoService
    {
        Task<IEnumerable<ContatoViewModel>> BuscarTodos();
        Task<ContatoViewModel> BuscarPorId(Guid id);
        Task<IEnumerable<ContatoViewModel>> BuscarPorRegiao(Guid idRegiao);
        Task<IEnumerable<ContatoViewModel>> BuscarPorDDD(Guid idDDD);
        Task Cadastrar(ContatoInputModel model);
        Task Alterar(ContatoUpdateInputModel model);
        Task Deletar(Guid id);
    }
}
