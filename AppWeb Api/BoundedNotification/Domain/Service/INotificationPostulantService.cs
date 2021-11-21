using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedNotification.Domain.Service.Communication;
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
namespace AppWeb_Api.BoundedNotification.Domain.Service
{
    public interface INotificationPostulantService
    {
        Task<IEnumerable<NotificationPostulant>> ListAsync();
        Task<NotificationPostulant> GetIdAsync(int id);
        Task<IEnumerable<NotificationPostulant>> ListByPostulantIdAsync(int postulantId);
        Task<Company> GetByCompanyIdAsync(int companyId);
        Task<Announcement> GetByAnnouncementIdAsync(int announcementId);
        Task<NotificationPostulantResponse> SaveAsync(NotificationPostulant notificationPostulant);
    }
}