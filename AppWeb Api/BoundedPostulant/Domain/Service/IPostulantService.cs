using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedPostulant.Domain.Service.Communication;
using AppWeb_Api.BoundedPostulant.Domain.Model;

namespace AppWeb_Api.BoundedPostulant.Domain.Service
{
    public interface IPostulantService
    {
        Task<IEnumerable<Postulant>> ListAsync();
        Task<Postulant> GetIdAsync(int id);
        Task<PostulantResponse> SaveAsync(Postulant postulant);
        Task<PostulantResponse> UpdateAsync(int id,Postulant postulant);
    }
}
