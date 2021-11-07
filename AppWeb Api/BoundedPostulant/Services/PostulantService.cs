using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedPostulant.Domain.Repository;
using AppWeb_Api.BoundedPostulant.Domain.Service;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.BoundedPostulant.Domain.Service.Communication;
using AppWeb_Api.Common.Domain.Repositories;

namespace AppWeb_Api.BoundedPostulant.Services
{
    public class PostulantService : IPostulantService
    {
        private readonly IPostulantRepository _postulantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PostulantService(IPostulantRepository postulantRepository, IUnitOfWork unitOfWork)
        {
            _postulantRepository = postulantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Postulant> GetIdAsync(int id)
        {
            return await _postulantRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Postulant>> ListAsync()
        {
            return await _postulantRepository.ListAsync();
        }

        public async Task<PostulantResponse> SaveAsync(Postulant postulant)
        {
            try
            {
                await _postulantRepository.AddAsync(postulant);
                await _unitOfWork.CompleteAsync();
                return new PostulantResponse(postulant);
            }
            catch(Exception e)
            {
                return new PostulantResponse($"An error ocurred while saving postulant:{e.Message}");
            }
        }

        public async Task<PostulantResponse> UpdateAsync(int id, Postulant postulant)
        {
            var existingPostulant = await _postulantRepository.FindByIdAsync(id);
            if (existingPostulant == null)
            {
                return new PostulantResponse("Postulant not found");
            }
            existingPostulant.Name = postulant.Name;
            existingPostulant.LastName = postulant.LastName;
            existingPostulant.MySpecialty = postulant.MySpecialty;
            existingPostulant.MyExperience = postulant.MyExperience;
            existingPostulant.Description = postulant.Description;
            existingPostulant.ImgPostulant = postulant.ImgPostulant;
            try
            {
                _postulantRepository.Update(existingPostulant);
                await _unitOfWork.CompleteAsync();
                return new PostulantResponse(existingPostulant);
            }
            catch(Exception e)
            {
                return new PostulantResponse($"An error ocurred while updating the postulant{e.Message}");
            }
        }
    }
}
