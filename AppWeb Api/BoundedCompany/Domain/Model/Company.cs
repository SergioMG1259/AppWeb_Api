namespace AppWeb_Api.BoundedCompany.Domain.Model
{
    // Company definition
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string ImgCompany{ get; set; }
    }
}