using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedApplication.Domain.Model;
using AppWeb_Api.BoundedNotification.Domain.Model;

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
        public DbSet<Application>Applications { get; set; }
        public DbSet<NotificationPostulant>NotificationPostulants { get; set; }
        public DbSet<NotificationCompany>NotificationsCompany { get; set; }
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
           /* builder.Entity<Postulant>().HasData(
               /new Postulant { Id=1,Name="Alejandro",LastName="Pizarro",Email="sergiogg1259@gmail.com",Password="123456789",
                    MySpecialty="Desarrollo movil",MyExperience="Semi-Senior",Description= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ultrices.",
                    NameGithub="sergiomg1259",ImgPostulant= "https://enlinea.santotomas.cl/wp-content/uploads/sites/2/2018/03/vu-700x465.png"
                },
                new Postulant { Id=2,Name="Carlos",LastName="Romero",Email="carlos1259@gmail.com",Password="123456789carlos",
                    MySpecialty="Desarrollo movil",MyExperience="Semi-Senior",Description= "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    NameGithub="sergiomg1259",ImgPostulant= "https://residenciauniversitariacartuja.es/wp-content/uploads/2017/04/Consejos-nuevos-estudiantes-universitarios.jpg"
                }
            );*/
           builder.Entity<Postulant>().HasMany(p => p.Projects)
               .WithOne(p => p.Postulant)
               .HasForeignKey(p => p.PostulantId);
            //Projects
            builder.Entity<Project>().ToTable("Projects");
            builder.Entity<Project>().HasKey(p => p.Id);
            builder.Entity<Project>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Project>().Property(p => p.Id).IsRequired().HasMaxLength(30);
           /* builder.Entity<Project>().HasData(
                new Project { Id=1,Title="Call of duty Mobile",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ultrices, turpis at facilisis bibendum, nulla urna vestibulum massa, sed blandit dolor orci eu ex. Aenean quam arcu, efficitur a vestibulum eget, ultrices in velit.",PostulantId=1,LinkToGithub="https://github.com/SergioMG1259/aplicacionesweb",ImgProject="https://i.blogs.es/f307c9/mob0/1366_2000.jpeg"},
                new Project { Id = 2, Title = "Battlefield 4", Description = "Jueguito chevere", PostulantId =1, LinkToGithub = "https://github.com/SergioMG1259/aplicacionesweb", ImgProject = "https://m.media-amazon.com/images/S/aplus-media/sota/e66cb100-e904-4f6b-beef-987c502a6b30.__CR0,0,970,600_PT0_SX970_V1___.jpg" },
                new Project { Id = 3, Title = "Minecraft", Description = "cubitos pro", PostulantId =2, LinkToGithub = "https://github.com/symphony701/IHC-Trabajo", ImgProject = "https://cdn.hobbyconsolas.com/sites/navi.axelspringer.es/public/media/image/2021/07/minecraft-2397153.jpg" }
            );*/
            //Relationship
            builder.Entity<Project>().HasMany(p => p.Evidences)
                .WithOne(p => p.Project)
                .HasForeignKey(p => p.ProjectId);
            //Evidences
            builder.Entity<Evidence>().ToTable("Evidences");
            builder.Entity<Evidence>().HasKey(p => p.Id);
            builder.Entity<Evidence>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Evidence>().Property(p => p.Id).IsRequired().HasMaxLength(30);
           /* builder.Entity<Evidence>().HasData(
                new Evidence { Id=1,Title="se222",ProjectId=1,ImgEvidence="pq"}
            );*/
            
            //Companies
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.Id).IsRequired().HasMaxLength(30);
            /*builder.Entity<Company>().HasData(
             new Company{Id=1,Name="Facebook",Email="facebook@gmail.com",Password ="123456face",Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ultrices, turpis at facilisis bibendum, nulla urna vestibulum massa, sed blandit dolor orci eu ex. Aenean quam arcu, efficitur a vestibulum eget, ultrices in velit. Ut vitae urna porta, auctor sapien eget, lobortis ipsum. Curabitur in eros mattis, dignissim urna eu, hendrerit neque. Pellentesque ultrices auctor mi nec facilisis.",ImgCompany = "https://play-lh.googleusercontent.com/aaEd3P5WVva-cBXIJaK72jSp-UQescXH8JPWkewsfeLmsQdaES7D8szhxz4e6KouaWg"}
             );*/
            builder.Entity<Company>().HasMany(p => p.Announcements)
                .WithOne(p => p.Company)
                .HasForeignKey(p => p.CompanyId);
            //Announcements
            builder.Entity<Announcement>().ToTable("Announcements");
            builder.Entity<Announcement>().HasKey(p => p.Id);
            builder.Entity<Announcement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Announcement>().Property(p => p.Id).IsRequired().HasMaxLength(30);
            
            //Applications
            builder.Entity<Application>().ToTable("Applications");
            builder.Entity<Application>().HasKey(p => p.Id);
            builder.Entity<Application>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Application>().Property(p => p.Id).IsRequired().HasMaxLength(30);
            
            //NotificationsPostulants
            builder.Entity<NotificationPostulant>().ToTable("NotificationsPostulants");
            builder.Entity<NotificationPostulant>().HasKey(p => p.Id);
            builder.Entity<NotificationPostulant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<NotificationPostulant>().Property(p => p.Id).IsRequired().HasMaxLength(30);
            
            //NotificationsCompany
            builder.Entity<NotificationCompany>().ToTable("NotificationsCompany");
            builder.Entity<NotificationCompany>().HasKey(p => p.Id);
            builder.Entity<NotificationCompany>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<NotificationCompany>().Property(p => p.Id).IsRequired().HasMaxLength(30);
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
