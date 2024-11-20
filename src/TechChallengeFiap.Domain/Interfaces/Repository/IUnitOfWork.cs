namespace TechChallengeFiap.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
