using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedCompany.Domain.Service.Communication;
using AppWeb_Api.BoundedCompany.Domain.Model;

namespace AppWeb_Api.BoundedCompany.Domain.Service
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> ListAsync();
        Task<Company> GetIdAsync(int id);
        Task<CompanyResponse> SaveAsync(Company company);
        Task<CompanyResponse> UpdateAsync(int id,Company company);
    }
}