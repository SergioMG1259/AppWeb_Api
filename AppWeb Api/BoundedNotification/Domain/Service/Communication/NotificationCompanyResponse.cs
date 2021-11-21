using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.Common.Domain.Services;
namespace AppWeb_Api.BoundedNotification.Domain.Service.Communication
{
    public class NotificationCompanyResponse:BaseResponse<NotificationCompany>
    {
        public NotificationCompanyResponse(string message) : base(message)
        {

        }
        public NotificationCompanyResponse(NotificationCompany notificationCompany) : base(notificationCompany)
        {

        }
    }
}