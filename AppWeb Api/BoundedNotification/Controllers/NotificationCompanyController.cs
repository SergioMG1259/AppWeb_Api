using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedNotification.Domain.Service;
using AppWeb_Api.BoundedNotification.Resources;
using AppWeb_Api.Common.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AppWeb_Api.BoundedNotification.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("/api/v1/notificationsCompany")]
    public class NotificationsCompanyController:ControllerBase
    {
        private readonly INotificationCompanyService _notificationCompanyService;
        private readonly IMapper _mapper;

        public NotificationsCompanyController(INotificationCompanyService notificationCompanyService, IMapper mapper)
        {
            _notificationCompanyService = notificationCompanyService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<NotificationCompanyResource>> GetAllAsync()
        {
            var notificationsCompany = await _notificationCompanyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<NotificationCompany>, IEnumerable<NotificationCompanyResource>>(notificationsCompany);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<NotificationCompanyResource> GetByIdAsync(int id)
        {
            var notificationCompany = await _notificationCompanyService.GetIdAsync(id);

            var notificationCompanyResource = _mapper.Map<NotificationCompany, NotificationCompanyResource>(notificationCompany);
            return notificationCompanyResource;
        }
        [HttpGet]
        [Route("/api/v1/notificationsCompany/companyId={id}")]
        public async Task<IEnumerable<NotificationCompanyResource>> GetByCompanyIdAsync(int id)
        {
            var notificationsCompany = await _notificationCompanyService.ListByCompanyIdAsync(id);
            var notificationsCompanyResource = _mapper.Map<IEnumerable<NotificationCompany>, IEnumerable<NotificationCompanyResource>>(notificationsCompany);
            return notificationsCompanyResource;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveNotificationCompanyResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var notificationCompany = _mapper.Map<SaveNotificationCompanyResource, NotificationCompany>(resource);
            var result = await _notificationCompanyService.SaveAsync(notificationCompany);
            if (!result.Succes)
                return BadRequest(result.Message);
            var notificationCompanyResource = _mapper.Map<NotificationCompany, NotificationCompanyResource>(result.Resource);
            return Ok(notificationCompanyResource);
        }
    }
}