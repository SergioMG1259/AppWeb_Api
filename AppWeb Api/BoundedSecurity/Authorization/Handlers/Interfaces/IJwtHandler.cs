
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.BoundedSecurity.Authorization.Handlers.Implementations;

namespace AppWeb_Api.BoundedSecurity.Authorization.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        public string GenerateTokenPostulant(Postulant postulant);
        public string GenerateTokenCompany(Company company);
        public int? ValidateToken(string token);
    }
}