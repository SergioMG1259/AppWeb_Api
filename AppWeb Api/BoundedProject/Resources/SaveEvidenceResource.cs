using System.ComponentModel.DataAnnotations;

namespace AppWeb_Api.BoundedProject.Resources
{
    public class SaveEvidenceResource
    {
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public string ImgEvidence { get; set; }
    }
}