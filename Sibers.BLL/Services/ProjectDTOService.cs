using AutoMapper;
using Sibers.BLL.DTO;
using Sibers.BLL.Interfaces;
using Sibers.Domain.Entities;
using Sibers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace Sibers.BLL.Services
{
    public class ProjectDTOService : IProjectDtoService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public ProjectDTOService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
        public void AddProject(ProjectDTO projectDTO, Guid[] selectedEmployees)
        {
            Project project = Mapper.Map<ProjectDTO, Project>(projectDTO);
            if (selectedEmployees != null)
            {
                project.Employees = new List<Employee>();
                //получаем выбранные курсы
                foreach (var c in _unitOfWork.Employees.GetAll().Where(co => selectedEmployees.Contains(co.EId)))
                {
                    project.Employees.Add(c);
                }
            }
            _unitOfWork.Projects.Create(project);
            _unitOfWork.Save();
        }

        public IEnumerable<EmployeeDTO> GetSelectedEmployees(ProjectDTO projectDTO)
        {
            Project project = Mapper.Map<ProjectDTO, Project>(projectDTO);
            var selectedEmployees = new List<Employee>();

            foreach (var employee in _unitOfWork.Employees.GetAll())
            {
                foreach (var employeeProject in projectDTO.Employees)
                {
                    if (employeeProject.EId == employee.EId) selectedEmployees.Add(employee);
                }
            }
            return Mapper.Map<List<Employee>, List<EmployeeDTO>>(selectedEmployees);
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var project = _unitOfWork.Employees.GetAll().ToList();

            return Mapper.Map<List<Employee>, List<EmployeeDTO>>(project);
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

        public ProjectDTO Get(Guid? id)
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
            var project = _unitOfWork.Projects.GetAll().Where(x=>x.ProjectName.Contains(search) || search == null).ToPagedList(pageNumber, pageSize);
            return Mapper.Map<IPagedList<Project>, IPagedList<ProjectDTO>>(project);
        }

        public void UpdateProject(ProjectDTO projectDTO, Guid[] selectedEmployees)
        {
            Project project = Mapper.Map<ProjectDTO, Project>(projectDTO);
            _unitOfWork.Projects.Update(project);
            _unitOfWork.Save();
        }
    }
}
