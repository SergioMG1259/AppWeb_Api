using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedCompany.Domain.Repository;
using AppWeb_Api.Common.Persistence.Contexts;
using AppWeb_Api.Common.Persistence.Repositories;
using AppWeb_Api.BoundedCompany.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AppWeb_Api.BoundedCompany.Persistence.Repository
{
    public class CompanyRepository:BaseRepository,ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> FindByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }
    }
}