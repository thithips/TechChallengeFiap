using TechChallengeFiap.Domain.Interfaces.Repository;
using TechChallengeFiap.Infrastructure.Contexto;

namespace TechChallengeFiap.Infrastructure.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContexto _context;

        public UnitOfWork(ApplicationDbContexto context) => _context = context;

        public async Task<bool> Commit() => await _context.SaveChangesAsync() > 0;
    }
}
