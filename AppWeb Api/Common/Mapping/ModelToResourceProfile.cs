using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.BoundedPostulant.Resources;
using AutoMapper;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.BoundedProject.Resources;
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedCompany.Resource;
using AppWeb_Api.BoundedAnnouncement.Resources;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.BoundedApplication.Domain.Model;
using AppWeb_Api.BoundedApplication.Resources;
using AppWeb_Api.BoundedCompany.Domain.Service.Communication;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedNotification.Resources;
using AppWeb_Api.BoundedPostulant.Domain.Service.Communication;

namespace AppWeb_Api.Common.Mapping
{
    public class ModelToResourceProfile:Profile
    {
        //Model
        public ModelToResourceProfile()
        {
            CreateMap<Postulant, PostulantResource>();
            CreateMap<Project, ProjectResource>();
            CreateMap<Evidence,EvidenceResource>();
            CreateMap<Company, CompanyResource>();
            CreateMap<Announcement, AnnouncementResource>();
            CreateMap<Application, ApplicationResource>();
            CreateMap<NotificationPostulant, NotificationPostulantResource>();
            CreateMap<NotificationCompany, NotificationCompanyResource>();
            CreateMap<Postulant, AuthenticatePostulantResponse>();
            CreateMap<Company, AuthenticateCompanyResponse>();
        }
    }
}
