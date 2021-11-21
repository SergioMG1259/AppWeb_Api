using AppWeb_Api.BoundedPostulant.Resources;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.BoundedProject.Resources;
using AppWeb_Api.BoundedCompany.Resource;
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedAnnouncement.Resources;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.BoundedApplication.Domain.Model;
using AppWeb_Api.BoundedApplication.Resources;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedNotification.Resources;
using AutoMapper;

namespace AppWeb_Api.Common.Mapping
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePostulantResource, Postulant>();
            CreateMap<UpdatePostulantResource, Postulant>();
            CreateMap<SaveProjectResource, Project>();
            CreateMap<UpdateProjectResource, Project>();
            CreateMap<SaveEvidenceResource, Evidence>();
            CreateMap<UpdateEvidenceResource,Evidence>();
            CreateMap<SaveCompanyResource, Company>();
            CreateMap<UpdateCompanyResource, Company>();
            CreateMap<UpdateAnnouncementResource, Announcement>();
            CreateMap<SaveAnnouncementResource, Announcement>();
            CreateMap<SaveApplicationResource, Application>();
            CreateMap<UpdateApplicationResource, Application>();
            CreateMap<SaveNotificationPostulantResource, NotificationPostulant>();
            CreateMap<SaveNotificationCompanyResource, NotificationCompany>();
        }
    }
}
