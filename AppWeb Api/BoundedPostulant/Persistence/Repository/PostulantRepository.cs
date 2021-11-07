using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedPostulant.Domain.Repository;
using AppWeb_Api.Common.Persistence.Contexts;
using AppWeb_Api.Common.Persistence.Repositories;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AppWeb_Api.BoundedPostulant.Persistence.Repository
{
    public class PostulantRepository : BaseRepository, IPostulantRepository
    {
        public PostulantRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsync(Postulant category)
        {
            await _context.Postulants.AddAsync(category);
        }

        public async Task<Postulant> FindByIdAsync(int id)
        {
            return await _context.Postulants.FindAsync(id);
        }

        public async Task<IEnumerable<Postulant>> ListAsync()
        {
            return await _context.Postulants.ToListAsync();
        }

        public void Update(Postulant postulant)
        {
            _context.Postulants.Update(postulant);
        }
    }
}
