using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;

namespace AppWeb_Api.BoundedAnnouncement.Domain.Repository
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> ListAsync();
        Task<Announcement> FindByIdAsync(int id);
        Task<IEnumerable<Announcement>> FindByCompanyId(int companyId);
        Task AddAsync(Announcement announcement);
        void Update(Announcement announcement);
        void Remove(Announcement announcement);
    }
}