using System.ComponentModel.DataAnnotations;
namespace AppWeb_Api.BoundedAnnouncement.Resources
{
    public class SaveAnnouncementResource
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public string RequiredSpecialty { get; set; }
        [Required]
        public string RequiredExperience { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string TypeMoney { get; set; }
        [Required]
        public bool Visible { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}