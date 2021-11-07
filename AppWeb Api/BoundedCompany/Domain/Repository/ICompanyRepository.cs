using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedCompany.Domain.Model;
// Company Persistence
namespace AppWeb_Api.BoundedCompany.Domain.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> ListAsync();
        Task<Company> FindByIdAsync(int id);
        Task AddAsync(Company company);
        void Update(Company company);
    }
}