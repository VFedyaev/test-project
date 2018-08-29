using AutoMapper;
using Sibers.BLL.DTO;
using Sibers.BLL.Interfaces;
using Sibers.DAL.Entities;
using Sibers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Sibers.BLL.ServiceModels
{
    public class EmployeeDTOService : IEmployeeDtoService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        
        public EmployeeDTOService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);
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

        public EmployeeDTO Get(Guid id)
        {
            var employee = _unitOfWork.Employees.Get(id);
            return Mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var employee = _unitOfWork.Employees.GetAll().ToList();
            return Mapper.Map<List<Employee>, List<EmployeeDTO>>(employee);
        }

        public IPagedList<EmployeeDTO> GetAllIndex(int pageNumber, int pageSize, string search)
        {
            var employee = _unitOfWork.Employees.GetAllIndex(pageNumber,pageSize, search);
            return Mapper.Map<IPagedList<Employee>, IPagedList<EmployeeDTO>>(employee.ToPagedList(pageNumber, pageSize));
        }
        

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);
            _unitOfWork.Employees.Update(employee);
            _unitOfWork.Save();
        }
    }
}
