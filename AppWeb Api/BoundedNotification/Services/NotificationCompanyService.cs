using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedNotification.Domain.Model;
using AppWeb_Api.BoundedNotification.Domain.Repository;
using AppWeb_Api.BoundedNotification.Domain.Service;
using AppWeb_Api.BoundedNotification.Domain.Service.Communication;
using AppWeb_Api.Common.Domain.Repositories;
namespace AppWeb_Api.BoundedNotification.Services
{
    public class NotificationCompanyService:INotificationCompanyService
    {
        private readonly INotificationCompanyRepository _notificationCompanyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationCompanyService(INotificationCompanyRepository notificationCompanyRepository, IUnitOfWork unitOfWork)
        {
            _notificationCompanyRepository = notificationCompanyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NotificationCompany>> ListAsync()
        {
            return await _notificationCompanyRepository.ListAsync();
        }

        public async Task<NotificationCompany> GetIdAsync(int id)
        {
            return await _notificationCompanyRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<NotificationCompany>> ListByCompanyIdAsync(int companyId)
        {
            return await _notificationCompanyRepository.FindByACompanyId(companyId);
        }

        public async Task<NotificationCompanyResponse> SaveAsync(NotificationCompany notificationCompany)
        {
            try
            {
                await _notificationCompanyRepository.AddAsync(notificationCompany);
                await _unitOfWork.CompleteAsync();
                return new NotificationCompanyResponse(notificationCompany);
            }
            catch (Exception e)
            {
                return new NotificationCompanyResponse($"An error ocurred while saving notification company:{e.Message}");
            }
        }
    }
}