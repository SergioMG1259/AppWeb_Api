using AppWeb_Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Domain.Repositories
{
    public interface IPostulantRepository
    {
        Task<IEnumerable<Postulant>> ListAsync();
        Task<Postulant> FindByIdAsync(int id);
        Task AddAsync(Postulant category);
        void Update(Postulant postulant);
    }
}
