using System.ComponentModel.DataAnnotations;
namespace AppWeb_Api.BoundedNotification.Resources
{
    public class SaveNotificationPostulantResource
    {
       [Required]
        public int PostulantId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string NameCompany { get; set; }
        [Required]
        public int AnnouncementId { get; set; }
        [Required]
        public string TitleAnnouncement { get; set; }
        [Required]
        public string Type { get; set; }
        public string Message { get; set; }
    }
}