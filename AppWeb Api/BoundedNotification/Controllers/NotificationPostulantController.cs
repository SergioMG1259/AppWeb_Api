using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedNotification.Domain.Service;
using AppWeb_Api.BoundedNotification.Resources;
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedCompany.Resource;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.BoundedAnnouncement.Resources;
using AppWeb_Api.Common.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AppWeb_Api.BoundedNotification.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("/api/v1/notificationsPostulant")]
    public class NotificationsPostulantController:ControllerBase
    {
        private readonly INotificationPostulantService _notificationPostulantService;
        private readonly IMapper _mapper;

        public NotificationsPostulantController(INotificationPostulantService notificationPostulantService, IMapper mapper)
        {
            _notificationPostulantService = notificationPostulantService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<NotificationPostulantResource>> GetAllAsync()
        {
            var notificationsPostulant = await _notificationPostulantService.ListAsync();
            var resources = _mapper.Map<IEnumerable<NotificationPostulant>, IEnumerable<NotificationPostulantResource>>(notificationsPostulant);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<NotificationPostulantResource> GetByIdAsync(int id)
        {
            var notificationPostulant = await _notificationPostulantService.GetIdAsync(id);

            var notificationPostulantResource = _mapper.Map<NotificationPostulant, NotificationPostulantResource>(notificationPostulant);
            return notificationPostulantResource;
        }
        [HttpGet]
        [Route("/api/v1/notificationsPostulant/postulantId={id}")]
        public async Task<IEnumerable<NotificationPostulantResource>> GetByPostulantIdAsync(int id)
        {
            var notificationsPostulant = await _notificationPostulantService.ListByPostulantIdAsync(id);
            var notificationsPostulantResource = _mapper.Map<IEnumerable<NotificationPostulant>, IEnumerable<NotificationPostulantResource>>(notificationsPostulant);
            return notificationsPostulantResource;
        }
        [HttpGet]
        [Route("/api/v1/notificationsPostulant/companyId={id}")]
        public async Task<CompanyResource> GetByCompanyIdAsync(int id)
        {
            var company = await _notificationPostulantService.GetByCompanyIdAsync(id);
            var companyResource = _mapper.Map<Company,CompanyResource>(company);
            return companyResource;
        }
        [HttpGet]
        [Route("/api/v1/notificationsPostulant/announcementId={id}")]
        public async Task<AnnouncementResource> GetByAnnouncementIdAsync(int id)
        {
            var announcement = await _notificationPostulantService.GetByAnnouncementIdAsync(id);
            var announcementResource = _mapper.Map<Announcement,AnnouncementResource>(announcement);
            return announcementResource;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveNotificationPostulantResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var notificationPostulant = _mapper.Map<SaveNotificationPostulantResource, NotificationPostulant>(resource);
            var result = await _notificationPostulantService.SaveAsync(notificationPostulant);
            if (!result.Succes)
                return BadRequest(result.Message);
            var notificationPostulantResource = _mapper.Map<NotificationPostulant, NotificationPostulantResource>(result.Resource);
            return Ok(notificationPostulantResource);
        }
    }
}