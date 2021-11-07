using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.BoundedAnnouncement.Domain.Service.Communication;

namespace AppWeb_Api.BoundedAnnouncement.Domain.Service
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<Announcement>> ListAsync();
        Task<Announcement> GetIdAsync(int id);
        Task<IEnumerable<Announcement>> ListByCompanyIdAsync(int companyId);

        Task<AnnouncementResponse> SaveAsync(Announcement announcement);
        Task<AnnouncementResponse> UpdateAsync(int id, Announcement announcement);
        Task<AnnouncementResponse> DeleteAsync(int id);
    }
}