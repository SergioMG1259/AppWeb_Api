using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb_Api.BoundedApplication.Domain.Model;
using AppWeb_Api.BoundedApplication.Domain.Repository;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.Common.Persistence.Contexts;
using AppWeb_Api.Common.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
namespace AppWeb_Api.BoundedApplication.Persistence.Repository
{
    public class ApplicationRepository:BaseRepository,IApplicationRepository
    {
        public ApplicationRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Application>> ListAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application> FindByIdAsync(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public async Task<IEnumerable<Application>> FindByAnnouncementId(int announcementId)
        {
            return await _context.Applications
                .Where(p => p.AnnouncementId == announcementId).ToListAsync();
        }

        public async Task<IEnumerable<Application>> FindByAnnouncementIdPostulantId(int announcementId, int postulantId)
        {
            return await _context.Applications
                .Where(p => p.AnnouncementId == announcementId && p.PostulantId==postulantId).ToListAsync();
        }

        public async Task<Postulant> FindByPostulantId(int postulantId)
        {
            return await _context.Postulants.FindAsync(postulantId);
        }

        public async Task AddAsync(Application application)
        {
            await _context.Applications.AddAsync(application);
        }

        public void Update(Application application)
        {
            _context.Applications.Update(application);
        }

        public void Remove(Application application)
        {
            _context.Applications.Remove(application);
        }
    }
}