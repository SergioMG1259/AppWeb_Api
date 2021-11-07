using System.Threading.Tasks;

namespace AppWeb_Api.Common.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task CompleteAsync();
    }
}
