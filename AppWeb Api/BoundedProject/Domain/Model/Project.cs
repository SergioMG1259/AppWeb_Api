using System.Collections.Generic;
using AppWeb_Api.BoundedPostulant.Domain.Model;

namespace AppWeb_Api.BoundedProject.Domain.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PostulantId { get; set; }
        public string LinkToGithub { get; set; }
        public string ImgProject { get; set; }
        public Postulant Postulant { get; set; }
        public IList<Evidence> Evidences { get; set; } = new List<Evidence>();
    }
}
