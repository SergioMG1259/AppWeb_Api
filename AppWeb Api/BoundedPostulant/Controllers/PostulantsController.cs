using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedPostulant.Domain.Service;
using AppWeb_Api.BoundedPostulant.Resources;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.Common.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

//backend postulant
namespace AppWeb_Api.BoundedPostulant.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PostulantsController:ControllerBase
    {
        private readonly IPostulantService _postulantService;
        private readonly IMapper _mapper;

        public PostulantsController(IPostulantService postulantService, IMapper mapper)
        {
            _postulantService = postulantService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PostulantResource>> GetAllAsync()
        {
            var postulants = await _postulantService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Postulant>, IEnumerable<PostulantResource>>(postulants);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<PostulantResource> GetByIdAsync(int id)
        {
            var postulant = await _postulantService.GetIdAsync(id);
            
            var postulantResource = _mapper.Map<Postulant, PostulantResource>(postulant);
            return postulantResource;
        }
        [HttpPost]
        public async Task<IActionResult>PostAsync([FromBody]SavePostulantResource resource)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var postulant = _mapper.Map<SavePostulantResource, Postulant>(resource);
            var result = await _postulantService.SaveAsync(postulant);
            if (!result.Succes)
                return BadRequest(result.Message);
            var postulantResource = _mapper.Map<Postulant, PostulantResource>(result.Resource);
            return Ok(postulantResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>PutAsync(int id,[FromBody] UpdatePostulantResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var postulant = _mapper.Map<UpdatePostulantResource, Postulant>(resource);
            var result = await _postulantService.UpdateAsync(id, postulant);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var postulantResource = _mapper.Map<Postulant, PostulantResource>(result.Resource);
            return Ok(postulantResource);
        }
    }
}
