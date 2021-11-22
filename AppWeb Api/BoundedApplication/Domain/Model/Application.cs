namespace AppWeb_Api.BoundedApplication.Domain.Model
{
    public class Application
    {
        public int Id { get; set; }
        public int PostulantId { get; set; }
        public int AnnouncementId { get; set; }
        public string State { get; set; }
    }
}