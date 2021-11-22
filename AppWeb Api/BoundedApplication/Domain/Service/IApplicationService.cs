using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedApplication.Domain.Model;
using AppWeb_Api.BoundedApplication.Domain.Service.Communication;
using AppWeb_Api.BoundedPostulant.Domain.Model;

namespace AppWeb_Api.BoundedApplication.Domain.Service
{
    public interface IApplicationService
    {
        Task<IEnumerable<Application>> ListAsync();
        Task<Application> GetIdAsync(int id);
        Task<IEnumerable<Application>> ListByAnnouncementIdAsync(int announcementId);
        Task<IEnumerable<Application>> ListByAnnouncementIdPostulantIdAsync(int announcementId,int postulantId);
        Task<Postulant> ListByPostulantIdAsync(int postulantId);
        Task<ApplicationResponse> SaveAsync(Application application);
        Task<ApplicationResponse> UpdateAsync(int id, Application application);
        Task<ApplicationResponse> DeleteAsync(int id);
    }
}