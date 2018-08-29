using Sibers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Sibers.BLL.Interfaces
{
    public interface IEmployeeDtoService
    {
        // Get all 
        IEnumerable<EmployeeDTO> GetAll();
        IPagedList<EmployeeDTO> GetAllIndex(int pageNumber, int pageSize, string search);
        
        EmployeeDTO Get(Guid id);
        void AddEmployee(EmployeeDTO employeeDTO);
        void DeleteEmployee(EmployeeDTO employeeDTO);
        void UpdateEmployee(EmployeeDTO employeeDTO);
        void Dispose();
    }
}
