namespace AppWeb_Api.BoundedNotification.Resources
{
    public class NotificationCompanyResource
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int AnnouncementId { get; set; }
        public string TitleAnnouncement { get; set; }
        public string Type { get; set; }
    }
}