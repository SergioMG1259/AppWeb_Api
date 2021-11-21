using System.ComponentModel.DataAnnotations;
namespace AppWeb_Api.BoundedNotification.Resources
{
    public class SaveNotificationCompanyResource
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public int AnnouncementId { get; set; }
        public string TitleAnnouncement { get; set; }
        [Required]
        public string Type { get; set; }
    }
}