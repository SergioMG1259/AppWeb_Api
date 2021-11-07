using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppWeb_Api.BoundedAnnouncement.Domain.Model;
using AppWeb_Api.BoundedAnnouncement.Domain.Repository;
using AppWeb_Api.BoundedAnnouncement.Domain.Service;
using AppWeb_Api.BoundedAnnouncement.Domain.Service.Communication;
using AppWeb_Api.Common.Domain.Repositories;
namespace AppWeb_Api.BoundedAnnouncement.Services
{
    public class AnnouncementService:IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementService(IAnnouncementRepository announcementRepository, IUnitOfWork unitOfWork)
        {
            _announcementRepository = announcementRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Announcement>> ListAsync()
        {
            return await _announcementRepository.ListAsync();
        }

        public async Task<Announcement> GetIdAsync(int id)
        {
            return await _announcementRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Announcement>> ListByCompanyIdAsync(int companyId)
        {
            return await _announcementRepository.FindByCompanyId(companyId);
        }

        public async Task<AnnouncementResponse> SaveAsync(Announcement announcement)
        {
            try
            {
                await _announcementRepository.AddAsync(announcement);
                await _unitOfWork.CompleteAsync();
                return new AnnouncementResponse(announcement);
            }
            catch (Exception e)
            {
                return new AnnouncementResponse($"An error ocurred while saving announcement:{e.Message}");
            }
        }

        public async Task<AnnouncementResponse> UpdateAsync(int id, Announcement announcement)
        {
            var existingAnnouncement = await _announcementRepository.FindByIdAsync(id);
            if (existingAnnouncement == null)
            {
                return new AnnouncementResponse("Announcement not found");
            }
            existingAnnouncement.Title = announcement.Title;
            existingAnnouncement.Description = announcement.Description;
            existingAnnouncement.RequiredExperience = announcement.RequiredExperience;
            existingAnnouncement.RequiredSpecialty = announcement.RequiredSpecialty;
            existingAnnouncement.Salary = announcement.Salary;
            existingAnnouncement.TypeMoney = announcement.TypeMoney;
            existingAnnouncement.Visible = announcement.Visible;
            existingAnnouncement.Date = announcement.Date;
            try
            {
                _announcementRepository.Update(existingAnnouncement);
                await _unitOfWork.CompleteAsync();
                return new AnnouncementResponse(existingAnnouncement);
            }
            catch (Exception e)
            {
                return new AnnouncementResponse($"An error ocurred while updating the announcement{e.Message}");
            }
        }

        public async Task<AnnouncementResponse> DeleteAsync(int id)
        {
            var existinAnnouncement = await _announcementRepository.FindByIdAsync(id);
            if (existinAnnouncement == null)
            {
                return new AnnouncementResponse("Announcement not found.");
            }
            try
            {
                _announcementRepository.Remove(existinAnnouncement);
                await _unitOfWork.CompleteAsync();
                return new AnnouncementResponse(existinAnnouncement);
            }
            catch (Exception e)
            {
                return new AnnouncementResponse($"An error occurred while deleting the announcement: {e.Message}");
            }
        }
    }
}
