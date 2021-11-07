using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.Common.Domain.Services;

namespace AppWeb_Api.BoundedProject.Domain.Service.Communication
{
    public class EvidenceResponse:BaseResponse<Evidence>
    {
        public EvidenceResponse(string message) : base(message)
        {

        }
        public EvidenceResponse(Evidence evidence) : base(evidence)
        {

        }
    }
}