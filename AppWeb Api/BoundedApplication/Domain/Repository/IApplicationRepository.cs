using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedApplication.Domain.Model;
using AppWeb_Api.BoundedPostulant.Domain.Model;

namespace AppWeb_Api.BoundedApplication.Domain.Repository
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> ListAsync();
        Task<Application> FindByIdAsync(int id);
        Task<IEnumerable<Application>> FindByAnnouncementId(int announcementId);
        Task<IEnumerable<Application>> FindByAnnouncementIdPostulantId(int announcementId,int postulantId);
        Task<Postulant> FindByPostulantId(int postulantId);
        Task AddAsync(Application application);
        void Update(Application application);
        void Remove(Application application);
    }
}