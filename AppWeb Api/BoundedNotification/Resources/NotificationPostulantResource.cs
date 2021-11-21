namespace AppWeb_Api.BoundedNotification.Resources
{
    public class NotificationPostulantResource
    {
        public int Id { get; set; }
        public int PostulantId { get; set; }
        public int CompanyId { get; set; }
        public string NameCompany { get; set; }
        public int AnnouncementId { get; set; }
        public string TitleAnnouncement { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}