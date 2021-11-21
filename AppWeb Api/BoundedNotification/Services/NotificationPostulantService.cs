using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedNotification.Domain.Repository;
using AppWeb_Api.BoundedNotification.Domain.Service;
using AppWeb_Api.BoundedNotification.Domain.Service.Communication;
using AppWeb_Api.BoundedCompany.Domain.Model;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.Common.Domain.Repositories;
namespace AppWeb_Api.BoundedNotification.Services
{
    public class NotificationPostulantService:INotificationPostulantService
    {
        private readonly INotificationPostulantRepository _notificationPostulantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationPostulantService(INotificationPostulantRepository notificationPostulantRepository, IUnitOfWork unitOfWork)
        {
            _notificationPostulantRepository = notificationPostulantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NotificationPostulant>> ListAsync()
        {
            return await _notificationPostulantRepository.ListAsync();
        }

        public async Task<NotificationPostulant> GetIdAsync(int id)
        {
            return await _notificationPostulantRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<NotificationPostulant>> ListByPostulantIdAsync(int postulantId)
        {
            return await _notificationPostulantRepository.FindByAPostulantId(postulantId);
        }

        public async Task<Company> GetByCompanyIdAsync(int companyId)
        {
            return await _notificationPostulantRepository.FindByCompanyId(companyId);
        }

        public async Task<Announcement> GetByAnnouncementIdAsync(int announcementId)
        {
            return await _notificationPostulantRepository.FindByAnnouncementId(announcementId);
        }

        public async Task<NotificationPostulantResponse> SaveAsync(NotificationPostulant notificationPostulant)
        {
            try
            {
                await _notificationPostulantRepository.AddAsync(notificationPostulant);
                await _unitOfWork.CompleteAsync();
                return new NotificationPostulantResponse(notificationPostulant);
            }
            catch (Exception e)
            {
                return new NotificationPostulantResponse($"An error ocurred while saving notification postulant:{e.Message}");
            }
        }
    }
}