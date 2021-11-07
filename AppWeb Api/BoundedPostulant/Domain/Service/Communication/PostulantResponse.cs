using AppWeb_Api.Common.Domain.Services;
using AppWeb_Api.BoundedPostulant.Domain.Model;

namespace AppWeb_Api.BoundedPostulant.Domain.Service.Communication
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
