using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedNotification.Domain.Service.Communication;
namespace AppWeb_Api.BoundedNotification.Domain.Service
{
    public interface INotificationCompanyService
    {
        Task<IEnumerable<NotificationCompany>> ListAsync();
        Task<NotificationCompany> GetIdAsync(int id);
        Task<IEnumerable<NotificationCompany>> ListByCompanyIdAsync(int companyId);
        Task<NotificationCompanyResponse> SaveAsync(NotificationCompany notificationCompany);
    }
}