using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedProject.Domain.Model;

namespace AppWeb_Api.BoundedProject.Domain.Repository
{
    public interface IEvidenceRepository
    {
        Task<IEnumerable<Evidence>> ListAsync();
        Task<Evidence> FindByIdAsync(int id);
        Task<IEnumerable<Evidence>> FindByProjectId(int projectId);
        Task AddAsync(Evidence evidence);
        void Update(Evidence evidence);
        void Remove(Evidence evidence);
    }
}