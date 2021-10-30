using AppWeb_Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Domain.Services.Communication
{
    public class PostulantResponse:BaseResponse<Postulant>
    {
        public PostulantResponse(string message) : base(message)
        {

        }
        public PostulantResponse(Postulant postulant) : base(postulant)
        {

        }
    }
}
