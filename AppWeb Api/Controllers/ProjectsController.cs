using AppWeb_Api.Domain.Models;
using AppWeb_Api.Domain.Services;
using AppWeb_Api.Extensions;
using AppWeb_Api.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    /*controlador*/
    public class ProjectsController:ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ProjectResource>> GetAllAsync()
        {
            var projects = await _projectService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<ProjectResource> GetByIdAsync(int id)
        {
            var project = await _projectService.GetIdAsync(id);

            var projectResource = _mapper.Map<Project, ProjectResource>(project);
            return projectResource;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProjectResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var project = _mapper.Map<SaveProjectResource, Project>(resource);
            var result = await _projectService.SaveAsync(project);
            if (!result.Succes)
                return BadRequest(result.Message);
            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateProjectResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var project = _mapper.Map<UpdateProjectResource, Project>(resource);
            var result = await _projectService.UpdateAsync(id, project);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectService.DeleteAsync(id);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }

        [HttpGet]
        [Route("/api/v1/postulants/{id}/projects")]
        public async Task<IEnumerable<ProjectResource>> GetByPostulantIdAsync(int id)
        {
            var projects = await _projectService.ListByPostulantIdAsync(id);

            var projectsResource = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);
            return projectsResource;
        }
    }
}
