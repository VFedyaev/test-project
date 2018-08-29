using AutoMapper;
using Sibers.BLL.DTO;
using Sibers.BLL.Interfaces;
using Sibers.DAL.Entities;
using Sibers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Sibers.BLL.ServiceModels
{
    public class ProjectDTOService : IProjectDtoService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public ProjectDTOService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
        public void AddProject(ProjectDTO projectDTO)
        {
            Project project = Mapper.Map<ProjectDTO, Project>(projectDTO);
            _unitOfWork.Projects.Create(project);
            _unitOfWork.Save();
        }

        public void DeleteProject(ProjectDTO projectDTO)
        {
            Project project = Mapper.Map<ProjectDTO, Project>(projectDTO);

            _unitOfWork.Projects.Delete(project.PId);
            _unitOfWork.
            Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public ProjectDTO Get(Guid id)
        {
            var project = _unitOfWork.Projects.Get(id);
            return Mapper.Map<Project, ProjectDTO>(project);
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            var project = _unitOfWork.Projects.GetAll().ToList();
            return Mapper.Map<List<Project>, List<ProjectDTO>>(project);
        }

        public IPagedList<ProjectDTO> GetAllIndex(int pageNumber, int pageSize, string search)
        {
            var project = _unitOfWork.Projects.GetAllIndex(pageNumber, pageSize, search);
            return Mapper.Map<IPagedList<Project>, IPagedList<ProjectDTO>>(project.ToPagedList(pageNumber, pageSize));
        }

        public void UpdateProject(ProjectDTO projectDTO)
        {
            Project project = Mapper.Map<ProjectDTO, Project>(projectDTO);
            _unitOfWork.Projects.Update(project);
            _unitOfWork.Save();
        }
    }
}
