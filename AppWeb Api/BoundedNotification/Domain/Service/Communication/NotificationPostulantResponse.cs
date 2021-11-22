using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.Common.Domain.Services;
namespace AppWeb_Api.BoundedNotification.Domain.Service.Communication
{
    public class NotificationPostulantResponse:BaseResponse<NotificationPostulant>
    {
        public NotificationPostulantResponse(string message) : base(message)
        {

        }
        public NotificationPostulantResponse(NotificationPostulant notificationPostulant) : base(notificationPostulant)
        {

        }
    }
}