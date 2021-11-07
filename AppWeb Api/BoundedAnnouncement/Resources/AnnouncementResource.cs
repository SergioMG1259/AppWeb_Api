namespace AppWeb_Api.BoundedAnnouncement.Resources
{
    public class AnnouncementResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RequiredSpecialty { get; set; }
        public string RequiredExperience { get; set; }
        public int Salary { get; set; }
        public string TypeMoney { get; set; }
        public bool Visible { get; set; }
        public string Date { get; set; }
    }
}