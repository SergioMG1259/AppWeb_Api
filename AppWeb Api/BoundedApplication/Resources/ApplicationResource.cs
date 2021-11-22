namespace AppWeb_Api.BoundedApplication.Resources
{
    public class ApplicationResource
    {
        public int Id { get; set; }
        public int PostulantId { get; set; }
        public int AnnouncementId { get; set; }
        public string State { get; set; }
    }
}