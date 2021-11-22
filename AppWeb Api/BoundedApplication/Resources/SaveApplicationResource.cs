using System.ComponentModel.DataAnnotations;
namespace AppWeb_Api.BoundedApplication.Resources
{
    public class SaveApplicationResource
    {
        [Required]
        public int PostulantId { get; set; }
        [Required]
        public int AnnouncementId { get; set; }
        [Required]
        public string State { get; set; }
    }
}