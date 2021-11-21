using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedNotification.Domain.Repository;
using AppWeb_Api.Common.Persistence.Contexts;
using AppWeb_Api.Common.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
namespace AppWeb_Api.BoundedNotification.Persistence.Repository
{
    public class NotificationCompanyRepository:BaseRepository,INotificationCompanyRepository
    {
        public NotificationCompanyRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<NotificationCompany>> ListAsync()
        {
            return await _context.NotificationsCompany.ToListAsync();
        }

        public async Task<NotificationCompany> FindByIdAsync(int id)
        {
            return await _context.NotificationsCompany.FindAsync(id);
        }

        public async Task<IEnumerable<NotificationCompany>> FindByACompanyId(int companyId)
        {
            return await _context.NotificationsCompany
                .Where(p=>p.CompanyId==companyId).ToListAsync();
        }

        public async Task AddAsync(NotificationCompany notificationCompany)
        {
            await _context.NotificationsCompany.AddAsync(notificationCompany);
        }
    }
}