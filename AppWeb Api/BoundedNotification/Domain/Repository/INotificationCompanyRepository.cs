using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedNotification.Domain.Model;
namespace AppWeb_Api.BoundedNotification.Domain.Repository
{
    public interface INotificationCompanyRepository
    {
        Task<IEnumerable<NotificationCompany>> ListAsync();
        Task<NotificationCompany> FindByIdAsync(int id);
        Task<IEnumerable<NotificationCompany>> FindByACompanyId(int companyId);
        Task AddAsync(NotificationCompany notificationCompany);
    }
}