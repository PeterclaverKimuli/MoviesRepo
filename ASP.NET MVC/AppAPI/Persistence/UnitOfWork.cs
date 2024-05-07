using AppAPI.Core.Interfaces;

namespace AppAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }
    }
}
