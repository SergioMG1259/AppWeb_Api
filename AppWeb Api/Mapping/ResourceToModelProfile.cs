using AppWeb_Api.Domain.Models;
using AppWeb_Api.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Mapping
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePostulantResource, Postulant>();
            CreateMap<SaveProjectResource, Project>();
            CreateMap<UpdateProjectResource, Project>();
        }
    }
}
