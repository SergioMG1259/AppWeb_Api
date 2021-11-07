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
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Project> GetIdAsync(int id)
        {
            return await _projectRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _projectRepository.ListAsync();
        }

        public async Task<IEnumerable<Project>> ListByPostulantIdAsync(int postulantId)
        {
            return await _projectRepository.FindByPostulantId(postulantId);
        }

        public async Task<ProjectResponse> SaveAsync(Project project)
        {
            try
            {
                await _projectRepository.AddAsync(project);
                await _unitOfWork.CompleteAsync();
                return new ProjectResponse(project);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error ocurred while saving project:{e.Message}");
            }
        }

        public async Task<ProjectResponse> UpdateAsync(int id, Project project)
        {
            var existingProject = await _projectRepository.FindByIdAsync(id);
            if (existingProject == null)
            {
                return new ProjectResponse("Project not found");
            }
            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.LinkToGithub = project.LinkToGithub;
            existingProject.ImgProject = project.ImgProject;
            try
            {
                _projectRepository.Update(existingProject);
                await _unitOfWork.CompleteAsync();
                return new ProjectResponse(existingProject);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error ocurred while updating the project{e.Message}");
            }
        }
        public async Task<ProjectResponse> DeleteAsync(int id)
        {
            var existinProject = await _projectRepository.FindByIdAsync(id);
            if (existinProject == null)
            {
                return new ProjectResponse("Project not found.");
            }
            try
            {
                _projectRepository.Remove(existinProject);
                await _unitOfWork.CompleteAsync();
                return new ProjectResponse(existinProject);
            }
            catch (Exception e)
            {
                return new ProjectResponse($"An error occurred while deleting the project: {e.Message}");
            }
        }
    }
}
