using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.BoundedAnnouncement.Domain.Service;
using AppWeb_Api.BoundedAnnouncement.Resources;
using AppWeb_Api.Common.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//Backend for data persistence announcement
namespace AppWeb_Api.BoundedAnnouncement.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AnnouncementsController:ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementsController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<AnnouncementResource>> GetAllAsync()
        {
            var announcements = await _announcementService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementResource>>(announcements);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<AnnouncementResource> GetByIdAsync(int id)
        {
            var announcement = await _announcementService.GetIdAsync(id);

            var announcementResource = _mapper.Map<Announcement, AnnouncementResource>(announcement);
            return announcementResource;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAnnouncementResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var announcement = _mapper.Map<SaveAnnouncementResource, Announcement>(resource);
            var result = await _announcementService.SaveAsync(announcement);
            if (!result.Succes)
                return BadRequest(result.Message);
            var announcementResource = _mapper.Map<Announcement, AnnouncementResource>(result.Resource);
            return Ok(announcementResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateAnnouncementResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var announcement = _mapper.Map<UpdateAnnouncementResource, Announcement>(resource);
            var result = await _announcementService.UpdateAsync(id, announcement);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var announcementResource = _mapper.Map<Announcement, AnnouncementResource>(result.Resource);
            return Ok(announcementResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _announcementService.DeleteAsync(id);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var announcementResource = _mapper.Map<Announcement, AnnouncementResource>(result.Resource);
            return Ok(announcementResource);
        }
        [HttpGet]
        [Route("/api/v1/companies/{id}/announcements")]
        public async Task<IEnumerable<AnnouncementResource>> GetByCompanyIdAsync(int id)
        {
            var announcements = await _announcementService.ListByCompanyIdAsync(id);
            var announcementsResource = _mapper.Map<IEnumerable<Announcement>, IEnumerable<AnnouncementResource>>(announcements);
            return announcementsResource;
        }
    }
}