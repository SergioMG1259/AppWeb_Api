using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.BoundedProject.Domain.Repository;
using AppWeb_Api.Common.Persistence.Contexts;
using AppWeb_Api.Common.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppWeb_Api.BoundedProject.Persistence.Repository
{
    public class EvidenceRepository:BaseRepository,IEvidenceRepository
    {
        public EvidenceRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Evidence>> ListAsync()
        {
            return await _context.Evidences.ToListAsync();
        }

        public async Task<Evidence> FindByIdAsync(int id)
        {
            return await _context.Evidences.FindAsync(id);
        }

        public async Task<IEnumerable<Evidence>> FindByProjectId(int projectId)
        {
            return await _context.Evidences
                .Where(p => p.ProjectId == projectId).ToListAsync();
        }

        public async Task AddAsync(Evidence evidence)
        {
            await _context.Evidences.AddAsync(evidence);
        }

        public void Update(Evidence evidence)
        {
            _context.Evidences.Update(evidence);
        }

        public void Remove(Evidence evidence)
        {
            _context.Evidences.Remove(evidence);
        }
    }
}