using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedProject.Domain.Model;

namespace AppWeb_Api.BoundedProject.Domain.Repository
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<Project> FindByIdAsync(int id);
        Task<IEnumerable<Project>> FindByPostulantId(int postulantId);
        Task AddAsync(Project project);
        void Update(Project project);
        void Remove(Project project);
    }
}
