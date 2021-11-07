using System.ComponentModel.DataAnnotations;
namespace AppWeb_Api.BoundedCompany.Resource
{
    public class SaveCompanyResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(60)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImgCompany { get; set; }
    }
}