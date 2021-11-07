using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.BoundedCompany.Domain.Model;

namespace AppWeb_Api.Common.Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Postulant> Postulants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Evidence>Evidences { get; set; }
        public DbSet<Company>Companies { get; set; }
        public DbSet<Announcement>Announcements { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Postulants
            //Contrainsts
            builder.Entity<Postulant>().ToTable("Postulants");
            builder.Entity<Postulant>().HasKey(p =>p.Id);
            builder.Entity<Postulant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Postulant>().Property(p => p.Id).IsRequired().HasMaxLength(30);
            //Relationships
            //Sample data
            builder.Entity<Postulant>().HasData(
                new Postulant { Id=100,Name="Alejandro",LastName="Pizarro",Email="sergiogg1259@gmail.com",Password="123456789",
                    MySpecialty="Desarrollo Movil",MyExperience="Semi-Senior",Description= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ultrices, turpis at facilisis bibendum, nulla urna vestibulum massa, sed blandit dolor orci eu ex.",
                    NameGithub="sergiomg1259",ImgPostulant= "https://enlinea.santotomas.cl/wp-content/uploads/sites/2/2018/03/vu-700x465.png"
                }
            );
            //Projects
            builder.Entity<Project>().ToTable("Projects");
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Project>().Property(p => p.Id).IsRequired().HasMaxLength(30);
            builder.Entity<Project>().HasData(
                new Project { Id=100,Title="se",Description="v",PostulantId=100,LinkToGithub="vxxa",ImgProject="pq"},
                new Project { Id = 101, Title = "se3", Description = "v2", PostulantId = 100, LinkToGithub = "vxx2", ImgProject = "pq2" },
                new Project { Id = 102, Title = "se3", Description = "v2", PostulantId = 101, LinkToGithub = "vxx2", ImgProject = "pq2" }
            );
            //Evidences
            builder.Entity<Evidence>().ToTable("Evidences");
            builder.Entity<Evidence>().HasKey(p => p.Id);
            builder.Entity<Evidence>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Evidence>().Property(p => p.Id).IsRequired().HasMaxLength(30);
            builder.Entity<Evidence>().HasData(
                new Evidence { Id=100,Title="se222",Description="v222",ProjectId=100,ImgEvidence="pq"}
            );
            //Companies
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.Id).IsRequired().HasMaxLength(30);
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
