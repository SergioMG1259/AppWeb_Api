using AppWeb_Api.Domain.Models;
using AppWeb_Api.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Mapping
{
    public class ModelToResourceProfile:Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Postulant, PostulantResource>();
            CreateMap<Project, ProjectResource>();
        }
    }
}
