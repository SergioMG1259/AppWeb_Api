using System.ComponentModel.DataAnnotations;

namespace AppWeb_Api.BoundedProject.Resources
{
    public class UpdateProjectResource
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public string LinkToGithub { get; set; }
        public string ImgProject { get; set; }
    }
}
