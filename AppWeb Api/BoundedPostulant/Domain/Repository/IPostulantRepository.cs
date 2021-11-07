using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedPostulant.Domain.Model;

namespace AppWeb_Api.BoundedPostulant.Domain.Repository
{
    public interface IPostulantRepository
    {
        Task<IEnumerable<Postulant>> ListAsync();
        Task<Postulant> FindByIdAsync(int id);
        Task AddAsync(Postulant category);
        void Update(Postulant postulant);
    }
}
