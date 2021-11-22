using AppWeb_Api.BoundedApplication.Domain.Model;
using AppWeb_Api.Common.Domain.Services;
namespace AppWeb_Api.BoundedApplication.Domain.Service.Communication
{
    public class ApplicationResponse:BaseResponse<Application>
    {
        public ApplicationResponse(string message) : base(message)
        {

        }
        public ApplicationResponse(Application application) : base(application)
        {

        }
    }
}