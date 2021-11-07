using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.BoundedProject.Domain.Service.Communication;

namespace AppWeb_Api.BoundedProject.Domain.Service
{
    public interface IEvidenceService
    {
        Task<IEnumerable<Evidence>> ListAsync();
        Task<Evidence> GetIdAsync(int id);
        Task<IEnumerable<Evidence>> ListByProjectIdAsync(int projectId);

        Task<EvidenceResponse> SaveAsync(Evidence evidence);
        Task<EvidenceResponse> UpdateAsync(int id, Evidence evidence);
        Task<EvidenceResponse> DeleteAsync(int id);
    }
}