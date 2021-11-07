using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.Common.Domain.Services;
namespace AppWeb_Api.BoundedAnnouncement.Domain.Service.Communication
{
    public class AnnouncementResponse:BaseResponse<Announcement>
    {
        public AnnouncementResponse(string message) : base(message)
        {

        }
        public AnnouncementResponse(Announcement announcement) : base(announcement)
        {

        }
    }
}