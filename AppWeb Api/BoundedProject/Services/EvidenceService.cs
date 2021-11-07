using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedProject.Domain.Model;
using AppWeb_Api.BoundedProject.Domain.Repository;
using AppWeb_Api.BoundedProject.Domain.Service;
using AppWeb_Api.BoundedProject.Domain.Service.Communication;
using AppWeb_Api.Common.Domain.Repositories;

namespace AppWeb_Api.BoundedProject.Services
{
    public class EvidenceService:IEvidenceService
    {
        private readonly IEvidenceRepository _evideceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EvidenceService(IEvidenceRepository evidenceRepository, IUnitOfWork unitOfWork)
        {
            _evideceRepository = evidenceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Evidence>> ListAsync()
        {
            return await _evideceRepository.ListAsync();
        }

        public async Task<Evidence> GetIdAsync(int id)
        {
            return await _evideceRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Evidence>> ListByProjectIdAsync(int projectId)
        {
            return await _evideceRepository.FindByProjectId(projectId);
        }

        public async Task<EvidenceResponse> SaveAsync(Evidence evidence)
        {
            try
            {
                await _evideceRepository.AddAsync(evidence);
                await _unitOfWork.CompleteAsync();
                return new EvidenceResponse(evidence);
            }
            catch (Exception e)
            {
                return new EvidenceResponse($"An error ocurred while saving evidence:{e.Message}");
            }
        }

        public async Task<EvidenceResponse> UpdateAsync(int id, Evidence evidence)
        {
            var existingEvidence = await _evideceRepository.FindByIdAsync(id);
            if (existingEvidence == null)
            {
                return new EvidenceResponse("Evidence not found");
            }
            existingEvidence.Title = evidence.Title;
            existingEvidence.Description = evidence.Description;
            existingEvidence.ImgEvidence = evidence.ImgEvidence;
            try
            {
                _evideceRepository.Update(existingEvidence);
                await _unitOfWork.CompleteAsync();
                return new EvidenceResponse(existingEvidence);
            }
            catch (Exception e)
            {
                return new EvidenceResponse($"An error ocurred while updating the Evidence{e.Message}");
            }

        }

        public async Task<EvidenceResponse> DeleteAsync(int id)
        {
            var existinEvidence = await _evideceRepository.FindByIdAsync(id);
            if (existinEvidence == null)
            {
                return new EvidenceResponse("Evidence not found.");
            }
            try
            {
                _evideceRepository.Remove(existinEvidence);
                await _unitOfWork.CompleteAsync();
                return new EvidenceResponse(existinEvidence);
            }
            catch (Exception e)
            {
                return new EvidenceResponse($"An error occurred while deleting the evidence: {e.Message}");
            }
        }
    }
}
