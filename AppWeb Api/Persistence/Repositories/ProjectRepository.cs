using AppWeb_Api.Domain.Models;
using AppWeb_Api.Domain.Repositories;
using AppWeb_Api.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Project> FindByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> FindByPostulantId(int postulantId)
        {
            return await _context.Projects
                .Where(p => p.PostulantId == postulantId).ToListAsync();
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }
    }
}
