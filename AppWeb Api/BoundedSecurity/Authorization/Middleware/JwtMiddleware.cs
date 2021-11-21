using System.Linq;
using System.Threading.Tasks;
using AppWeb_Api.BoundedCompany.Domain.Service;
using AppWeb_Api.BoundedPostulant.Domain.Service;
using AppWeb_Api.BoundedSecurity.Authorization.Handlers.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AppWeb_Api.BoundedSecurity.Authorization.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;


        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IPostulantService userService, IJwtHandler handler,ICompanyService companyService)
        {
            var token = context.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();
            var userId = handler.ValidateToken(token);

            if (userId != null)
            {
                // Attach user to context
                context.Items["Postulant"] = await userService.GetIdAsync(userId.Value);
            }
                
            await _next(context);

        }

        
    }
}