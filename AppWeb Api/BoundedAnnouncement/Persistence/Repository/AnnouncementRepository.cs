using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.BoundedAnnouncement.Domain.Repository;
using AppWeb_Api.Common.Persistence.Contexts;
using AppWeb_Api.Common.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
namespace AppWeb_Api.BoundedAnnouncement.Persistence.Repository
{
    public class AnnouncementRepository: BaseRepository, IAnnouncementRepository
    {
        public AnnouncementRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Announcement>> ListAsync()
        {
            return await _context.Announcements.ToListAsync();
        }

        public async Task<Announcement> FindByIdAsync(int id)
        {
            return await _context.Announcements.FindAsync(id);
        }

        public async Task<IEnumerable<Announcement>> FindByCompanyId(int companyId)
        {
            return await _context.Announcements
                .Where(p => p.CompanyId == companyId).ToListAsync();
        }

        public async Task AddAsync(Announcement announcement)
        {
            await _context.Announcements.AddAsync(announcement);
        }

        public void Update(Announcement announcement)
        {
            _context.Announcements.Update(announcement);
        }

        public void Remove(Announcement announcement)
        {
            _context.Announcements.Remove(announcement);
        }
    }
}