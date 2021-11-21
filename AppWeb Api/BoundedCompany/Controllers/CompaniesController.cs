using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedCompany.Domain.Service;
using AppWeb_Api.BoundedCompany.Resource;
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedCompany.Domain.Service.Communication;
using AppWeb_Api.BoundedSecurity.Authorization.Attributes;
using AppWeb_Api.Common.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BCryptNet = BCrypt.Net.BCrypt;

//Access Company
namespace AppWeb_Api.BoundedCompany.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("/api/v1/companies")]
    public class CompaniesController:ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<CompanyResource>> GetAllAsync()
        {
            var companies = await _companyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<CompanyResource> GetByIdAsync(int id)
        {
            var company = await _companyService.GetIdAsync(id);
            
            var companyResource = _mapper.Map<Company, CompanyResource>(company);
            return companyResource;
        }
        [AllowAnonymous]
        [HttpPost("auth/sign-up")]
        public async Task<IActionResult>PostAsync([FromBody]SaveCompanyResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var company = _mapper.Map<SaveCompanyResource, Company>(resource);
            company.Password = BCryptNet.HashPassword(resource.Password);
            var result = await _companyService.SaveAsync(company);
            if (!result.Succes)
                return BadRequest(result.Message);
            var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>PutAsync(int id,[FromBody] UpdateCompanyResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var company = _mapper.Map<UpdateCompanyResource, Company>(resource);
            var result = await _companyService.UpdateAsync(id, company);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }
        [AllowAnonymous]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate(AuthenticateCompanyRequest request)
        {
            var response = await _companyService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(response);
        }
    }
}