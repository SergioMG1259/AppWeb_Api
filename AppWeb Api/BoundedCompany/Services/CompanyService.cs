using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedCompany.Domain.Repository;
using AppWeb_Api.BoundedCompany.Domain.Service;
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedCompany.Domain.Service.Communication;
using AppWeb_Api.Common.Domain.Repositories;

//Access Company Service
namespace AppWeb_Api.BoundedCompany.Services
{
    public class CompanyService:ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            return await _companyRepository.ListAsync();
        }

        public async Task<Company> GetIdAsync(int id)
        {
            return await _companyRepository.FindByIdAsync(id);
        }

        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();
                return new CompanyResponse(company);
            }
            catch(Exception e)
            {
                return new CompanyResponse($"An error ocurred while saving company:{e.Message}");
            }
        }

        public async Task<CompanyResponse> UpdateAsync(int id, Company company)
        {
            var existingCompany = await _companyRepository.FindByIdAsync(id);
            if (existingCompany == null)
            {
                return new CompanyResponse("Company not found");
            }
            existingCompany.Name = company.Name;
            existingCompany.Description = company.Description;
            existingCompany.ImgCompany = company.ImgCompany;
            try
            {
                _companyRepository.Update(existingCompany);
                await _unitOfWork.CompleteAsync();
                return new CompanyResponse(existingCompany);
            }
            catch(Exception e)
            {
                return new CompanyResponse($"An error ocurred while updating the company{e.Message}");
            }
        }
    }
}