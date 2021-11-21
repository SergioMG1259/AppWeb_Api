using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
namespace AppWeb_Api.BoundedNotification.Domain.Repository
{
    public interface INotificationPostulantRepository
    {
        Task<IEnumerable<NotificationPostulant>> ListAsync();
        Task<NotificationPostulant> FindByIdAsync(int id);
        Task<IEnumerable<NotificationPostulant>> FindByAPostulantId(int postulantId);
        Task<Company> FindByCompanyId(int companyId);
        Task<Announcement> FindByAnnouncementId(int announcementId);
        Task AddAsync(NotificationPostulant notificationPostulant);
    }
}