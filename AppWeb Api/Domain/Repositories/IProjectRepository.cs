using AppWeb_Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<Project> FindByIdAsync(int id);
        Task<IEnumerable<Project>> FindByPostulantId(int postulantId);
        Task AddAsync(Project project);
        void Update(Project project);
        void Remove(Project project);
    }
}
