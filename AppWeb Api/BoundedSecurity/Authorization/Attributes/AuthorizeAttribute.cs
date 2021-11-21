using System;
using System.Linq;
using AppWeb_Api.BoundedCompany.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AppWeb_Api.BoundedPostulant.Domain.Model;

namespace AppWeb_Api.BoundedSecurity.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
            // If action is decorated with [AllowAnonymous] attribute
            var allowAnonymous =
                context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

            // Then skip authorization process
            if (allowAnonymous)
                return;

            // Authorization process
            var user = (Postulant)context.HttpContext.Items["Postulant"];

            if (user == null)
            {
                // Not logged in at this moment
                context.Result = new JsonResult(new { message = "Unauthorized" })
                    { StatusCode = StatusCodes.Status401Unauthorized };
            }
            //var user = (Company)context.HttpContext.Items["Company"];
            //var user = (Postulant)context.HttpContext.Items["Postulant"];
            //Console.WriteLine(user);

            /*if (usercompany == null && userpostulant == null)
            {
                // Not logged in at this moment
                context.Result = new JsonResult(new { message = "Unauthorized" })
                    { StatusCode = StatusCodes.Status401Unauthorized };
            }*/
            
        }
    }
}

