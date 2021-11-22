using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedApplication.Domain.Model;
using AppWeb_Api.BoundedApplication.Domain.Repository;
using AppWeb_Api.BoundedApplication.Domain.Service;
using AppWeb_Api.BoundedApplication.Domain.Service.Communication;
using AppWeb_Api.BoundedPostulant.Domain.Model;
using AppWeb_Api.Common.Domain.Repositories;
namespace AppWeb_Api.BoundedApplication.Services
{
    public class ApplicationService:IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IApplicationRepository applicationRepository, IUnitOfWork unitOfWork)
        {
            _applicationRepository = applicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Application>> ListAsync()
        {
            return await _applicationRepository.ListAsync();
        }

        public async Task<Application> GetIdAsync(int id)
        {
            return await _applicationRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Application>> ListByAnnouncementIdAsync(int announcementId)
        {
            return await _applicationRepository.FindByAnnouncementId(announcementId);
        }

        public async Task<IEnumerable<Application>> ListByAnnouncementIdPostulantIdAsync(int announcementId, int postulantId)
        {
            return await _applicationRepository.FindByAnnouncementIdPostulantId(announcementId,postulantId);
        }

        public async Task<Postulant> ListByPostulantIdAsync(int postulantId)
        {
            return await _applicationRepository.FindByPostulantId(postulantId);
        }

        public async Task<ApplicationResponse> SaveAsync(Application application)
        {
            try
            {
                await _applicationRepository.AddAsync(application);
                await _unitOfWork.CompleteAsync();
                return new ApplicationResponse(application);
            }
            catch (Exception e)
            {
                return new ApplicationResponse($"An error ocurred while saving application:{e.Message}");
            }
        }

        public async Task<ApplicationResponse> UpdateAsync(int id, Application application)
        {
            var existingApplication = await _applicationRepository.FindByIdAsync(id);
            if (existingApplication == null)
            {
                return new ApplicationResponse("Application not found");
            }
           
            existingApplication.State = application.State;
            try
            {
                _applicationRepository.Update(existingApplication);
                await _unitOfWork.CompleteAsync();
                return new ApplicationResponse(existingApplication);
            }
            catch (Exception e)
            {
                return new ApplicationResponse($"An error ocurred while updating the application{e.Message}");
            }
        }

        public async Task<ApplicationResponse> DeleteAsync(int id)
        {
            var existingApplication = await _applicationRepository.FindByIdAsync(id);
            if (existingApplication == null)
            {
                return new ApplicationResponse("Application not found.");
            }
            try
            {
                _applicationRepository.Remove(existingApplication);
                await _unitOfWork.CompleteAsync();
                return new ApplicationResponse(existingApplication);
            }
            catch (Exception e)
            {
                return new ApplicationResponse($"An error occurred while deleting the application: {e.Message}");
            }
        }
    }
}