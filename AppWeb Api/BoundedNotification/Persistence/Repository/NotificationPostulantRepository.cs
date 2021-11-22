using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedNotification.Domain.Repository;
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.Common.Persistence.Contexts;
using AppWeb_Api.Common.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
namespace AppWeb_Api.BoundedNotification.Persistence.Repository
{
    public class NotificationPostulantRepository:BaseRepository,INotificationPostulantRepository
    {
        public NotificationPostulantRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<NotificationPostulant>> ListAsync()
        {
            return await _context.NotificationPostulants.ToListAsync();
        }

        public async Task<NotificationPostulant> FindByIdAsync(int id)
        {
            return await _context.NotificationPostulants.FindAsync(id);
        }

        public async Task<IEnumerable<NotificationPostulant>> FindByAPostulantId(int postulantId)
        {
            return await _context.NotificationPostulants
                .Where(p=>p.PostulantId==postulantId).ToListAsync();
        }

        public async Task<Company> FindByCompanyId(int companyId)
        {
            return await _context.Companies.FindAsync(companyId);
        }

        public async Task<Announcement> FindByAnnouncementId(int announcementId)
        {
            return await _context.Announcements.FindAsync(announcementId);
        }

        public async Task AddAsync(NotificationPostulant notificationPostulant)
        {
            await _context.NotificationPostulants.AddAsync(notificationPostulant);
        }
    }
}