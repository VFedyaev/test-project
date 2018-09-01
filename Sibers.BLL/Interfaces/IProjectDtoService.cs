using Sibers.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace Sibers.BLL.Interfaces
{
    public interface IProjectDtoService
    {
        // Get all 
        IEnumerable<ProjectDTO> GetAll();
        IEnumerable<EmployeeDTO> GetSelectedEmployees(ProjectDTO projectDTO);
        IEnumerable<EmployeeDTO> GetAllEmployees();
        IPagedList<ProjectDTO> GetAllIndex(int pageNumber, int pageSize, string search);
        ProjectDTO Get(Guid? id);
        void AddProject(ProjectDTO projectDTO, Guid[] selectedEmployees);
        void DeleteProject(ProjectDTO projectDTO);
        void UpdateProject(ProjectDTO projectDTO, Guid[] selectedEmployees);
        void Dispose();
    }
}
