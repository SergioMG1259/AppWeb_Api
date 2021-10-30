using AppWeb_Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Domain.Services.Communication
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
