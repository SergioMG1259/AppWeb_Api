using System.ComponentModel.DataAnnotations;
namespace AppWeb_Api.BoundedAnnouncement.Resources
{
    public class UpdateAnnouncementResource
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
      
        public string RequiredSpecialty { get; set; }
        
        public string RequiredExperience { get; set; }
        
        public int Salary { get; set; }
       
        public string TypeMoney { get; set; }
       
        public bool Visible { get; set; }
       
        public string Date { get; set; }
        
    }
}