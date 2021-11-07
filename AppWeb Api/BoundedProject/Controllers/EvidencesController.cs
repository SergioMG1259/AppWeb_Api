using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.BoundedProject.Domain.Service;
using AppWeb_Api.BoundedProject.Resources;
using AppWeb_Api.Common.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//Esta es la clase controlador de las evidencias 
namespace AppWeb_Api.BoundedProject.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class EvidencesController:ControllerBase
    {
        private readonly IEvidenceService _evidenceService;
        private readonly IMapper _mapper;

        public EvidencesController(IEvidenceService evidenceService, IMapper mapper)
        {
            _evidenceService = evidenceService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<EvidenceResource>> GetAllAsync()
        {
            var evidences = await _evidenceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Evidence>, IEnumerable<EvidenceResource>>(evidences);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<EvidenceResource> GetByIdAsync(int id)
        {
            var evidence = await _evidenceService.GetIdAsync(id);

            var evidenceResource = _mapper.Map<Evidence, EvidenceResource>(evidence);
            return evidenceResource;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateEvidenceResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var evidence = _mapper.Map<UpdateEvidenceResource, Evidence>(resource);
            var result = await _evidenceService.UpdateAsync(id, evidence);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var evidenceResource = _mapper.Map<Evidence, EvidenceResource>(result.Resource);
            return Ok(evidenceResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _evidenceService.DeleteAsync(id);
            if (!result.Succes)
            {
                return BadRequest(result.Message);
            }
            var evidenceResource = _mapper.Map<Evidence, EvidenceResource>(result.Resource);
            return Ok(evidenceResource);
        }
    }
}
