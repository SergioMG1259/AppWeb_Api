using AppWeb_Api.Domain.Models;
using AppWeb_Api.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Domain.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<Project> GetIdAsync(int id);
        Task<IEnumerable<Project>> ListByPostulantIdAsync(int postulantId);

        Task<ProjectResponse> SaveAsync(Project project);
        Task<ProjectResponse> UpdateAsync(int id, Project project);
        Task<ProjectResponse> DeleteAsync(int id);
    }
}
