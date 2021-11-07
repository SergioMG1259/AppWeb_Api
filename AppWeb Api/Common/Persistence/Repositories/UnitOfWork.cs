using System.Threading.Tasks;
using AppWeb_Api.Common.Domain.Repositories;
using AppWeb_Api.Common.Persistence.Contexts;

namespace AppWeb_Api.Common.Persistence.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
