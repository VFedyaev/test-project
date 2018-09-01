using AutoMapper;
using Sibers.BLL.DTO;
using Sibers.BLL.Interfaces;
using Sibers.Domain.Entities;
using Sibers.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace Sibers.BLL.Services
{
    public class EmployeeDTOService : IEmployeeDtoService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        
        public EmployeeDTOService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
        public void AddEmployee(EmployeeDTO employeeDTO, Guid[] selectedProjects)
        {
            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);
            var projects = _unitOfWork.Projects.GetAll();
            if (selectedProjects != null)
            {
                employee.Projects = new List<Project>();
                foreach (var project in projects.Where(x => selectedProjects.Contains(x.PId)))
                {
                    employee.Projects.Add(project);
                }
            }
            _unitOfWork.Employees.Create(employee);
            _unitOfWork.Save();
        }

        public void DeleteEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);

            _unitOfWork.Employees.Delete(employee.EId);
            _unitOfWork.
            Save();
        }

        public EmployeeDTO Get(Guid? id)
        {
            var employee = _unitOfWork.Employees.Get(id);
            return Mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employee = _unitOfWork.Employees.GetAll().ToList();
            return Mapper.Map<List<Employee>, List<EmployeeDTO>>(employee);
        }

        public IPagedList<EmployeeDTO> GetAllIndex(int pageNumber, int pageSize, string search)
        {
            var employee = _unitOfWork.Employees.GetAll().Where(x=>x.FirstName.Contains(search) || search == null).ToPagedList(pageNumber, pageSize);
            return Mapper.Map<IPagedList<Employee>, IPagedList<EmployeeDTO>>(employee);
        }
        

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO, Guid[] selectedProjects)
        {
            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);
            employee.Projects.Clear();
            if (selectedProjects != null)
            {
                foreach (var c in _unitOfWork.Projects.GetAll().Where(co => selectedProjects.Contains(co.PId)))
                {
                    employee.Projects.Add(c);
                }
            }
            _unitOfWork.Employees.Update(employee);
            _unitOfWork.Save();
        }

        public IEnumerable<ProjectDTO> GetSelectedProjects(EmployeeDTO employeeDTO)
        {
            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);
            var selectedProjects = new List<Project>();

            foreach (var project in _unitOfWork.Projects.GetAll())
            {
                foreach (var employeeProject in employeeDTO.Projects)
                {
                    if (employeeProject.PId == project.PId) selectedProjects.Add(project);
                }
            }
            return Mapper.Map<List<Project>, List<ProjectDTO>>(selectedProjects);
        }
        public IEnumerable<ProjectDTO> GetAllProjects()
        {
            var projects = _unitOfWork.Projects.GetAll().ToList();
            return Mapper.Map<List<Project>, List<ProjectDTO>>(projects);
        }
    }
}
