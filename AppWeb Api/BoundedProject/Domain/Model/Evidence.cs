namespace AppWeb_Api.BoundedProject.Domain.Model
{
    public class Evidence
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProjectId { get; set; }
        public string ImgEvidence { get; set; }
        public Project Project { get; set; }
    }
}