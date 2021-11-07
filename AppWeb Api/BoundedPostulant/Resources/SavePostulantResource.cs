using System.ComponentModel.DataAnnotations;

namespace AppWeb_Api.BoundedPostulant.Resources
{
    public class SavePostulantResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(60)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        public string MySpecialty { get; set; }
        [Required]
        public string MyExperience { get; set; }
        [Required]
        [MaxLength(600)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameGithub { get; set; }
        [Required]
        public string ImgPostulant { get; set; }
    }
}
