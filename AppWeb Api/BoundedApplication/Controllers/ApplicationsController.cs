using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedApplication.Domain.Model;
using AppWeb_Api.BoundedApplication.Domain.Service;
using AppWeb_Api.BoundedApplication.Resources;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.BoundedPostulant.Resources;
using AppWeb_Api.Common.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AppWeb_Api.BoundedApplication.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ApplicationsController:ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationsController(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ApplicationResource>> GetAllAsync()
        {
            var applications = await _applicationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Application>, IEnumerable<ApplicationResource>>(applications);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<ApplicationResource> GetByIdAsync(int id)
        {
            var application = await _applicationService.GetIdAsync(id);

            var applicationResource = _mapper.Map<Application, ApplicationResource>(application);
            return applicationResource;
        }
        [HttpGet]
        [Route("/api/v1/applications/announcementId={id}")]
        public async Task<IEnumerable<ApplicationResource>> GetByAnnouncementIdAsync(int id)
        {
            var applications = await _applicationService.ListByAnnouncementIdAsync(id);
            var applicationsResource = _mapper.Map<IEnumerable<Application>, IEnumerable<ApplicationResource>>(applications);
            return applicationsResource;
        }
        [HttpGet]
        [Route("/api/v1/applications/announcementId={ida}/postulantId={idp}")]
        public async Task<IEnumerable<ApplicationResource>> GetByAnnouncementIdPostulantIdAsync(int ida,int idp)
        {
            var applications = await _applicationService.ListByAnnouncementIdPostulantIdAsync(ida,idp);
            var applicationsResource = _mapper.Map<IEnumerable<Application>, IEnumerable<ApplicationResource>>(applications);
            return applicationsResource;
        }
        [HttpGet]
        [Route("/api/v1/applications/postulantId={id}")]
        public async Task<PostulantResource> GetByPostulantIdAsync(int id)
        {
            var postulant = await _applicationService.ListByPostulantIdAsync(id);
            var postulantResource = _mapper.Map<Postulant,PostulantResource>(postulant);
            return postulantResource;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveApplicationResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var application = _mapper.Map<SaveApplicationResource, Application>(resource);
            var result = await _applicationService.SaveAsync(application);
            if (!result.Succes)
                return BadRequest(result.Message);
            var applicationResource = _mapper.Map<Application, ApplicationResource>(result.Resource);
            return Ok(applicationResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateApplicationResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var application = _mapper.Map<UpdateApplicationResource, Application>(resource);
            var result = await _applicationService.UpdateAsync(id, application);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var applicationResource = _mapper.Map<Application, ApplicationResource>(result.Resource);
            return Ok(applicationResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _applicationService.DeleteAsync(id);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var applicationResource = _mapper.Map<Application, ApplicationResource>(result.Resource);
            return Ok(applicationResource);
        }
    }
}