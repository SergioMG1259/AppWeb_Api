using AppWeb_Api.Domain.Models;
using AppWeb_Api.Domain.Repositories;
using AppWeb_Api.Domain.Services;
using AppWeb_Api.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb_Api.Services
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
                return new PostulantResponse($"An error ocurred while updating the category{e.Message}");
            }
        }
    }
}
