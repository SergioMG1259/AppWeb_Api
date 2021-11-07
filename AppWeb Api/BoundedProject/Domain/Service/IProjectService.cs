using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.BoundedProject.Domain.Service.Communication;

namespace AppWeb_Api.BoundedProject.Domain.Service
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
