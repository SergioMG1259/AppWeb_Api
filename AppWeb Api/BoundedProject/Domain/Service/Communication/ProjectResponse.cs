using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.Common.Domain.Services;

namespace AppWeb_Api.BoundedProject.Domain.Service.Communication
{
    public class ProjectResponse:BaseResponse<Project>
    {
        public ProjectResponse(string message) : base(message)
        {

        }
        public ProjectResponse(Project project) : base(project)
        {

        }
    }
}
