using System.ComponentModel.DataAnnotations;

namespace AppWeb_Api.BoundedProject.Resources
{
    public class UpdateEvidenceResource
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }
        [Required]
        public string ImgEvidence { get; set; }
    }
}