using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.Common.Domain.Services;

namespace AppWeb_Api.BoundedCompany.Domain.Service.Communication
{
    public class CompanyResponse:BaseResponse<Company>
    {
        public CompanyResponse(string message) : base(message)
        {

        }
        public CompanyResponse(Company company) : base(company)
        {

        }
    }
}