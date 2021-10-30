using AppWeb_Api.Domain.Models;
using AppWeb_Api.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Domain.Services
{
    public interface IPostulantService
    {
        Task<IEnumerable<Postulant>> ListAsync();
        Task<Postulant> GetIdAsync(int id);
        Task<PostulantResponse> SaveAsync(Postulant postulant);
        Task<PostulantResponse> UpdateAsync(int id, Postulant postulant);
    }
}
