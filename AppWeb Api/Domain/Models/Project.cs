using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PostulantId { get; set; }
        public string LinkToGithub { get; set; }
        public string ImgProject { get; set; }
    }
}
