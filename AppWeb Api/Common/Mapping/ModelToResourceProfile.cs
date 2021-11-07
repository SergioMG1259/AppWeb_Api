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

namespace AppWeb_Api.Common.Mapping
{
    public class ModelToResourceProfile:Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Postulant, PostulantResource>();
            CreateMap<Project, ProjectResource>();
            CreateMap<Evidence,EvidenceResource>();
            CreateMap<Company, CompanyResource>();
            CreateMap<Announcement, AnnouncementResource>();
        }
    }
}
