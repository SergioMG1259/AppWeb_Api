﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Resources
{
    public class PostulantResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MySpecialty { get; set; }
        public string MyExperience { get; set; }
        public string Description { get; set; }
        public string NameGithub { get; set; }
        public string ImgPostulant { get; set; }
    }
}
