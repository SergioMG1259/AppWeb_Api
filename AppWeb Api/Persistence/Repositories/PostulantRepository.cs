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
