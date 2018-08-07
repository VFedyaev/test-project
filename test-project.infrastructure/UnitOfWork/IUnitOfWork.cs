using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testproject.infrastructure.Repositories;

namespace testproject.infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        EmployeeRepository Employees { get; }
        ProjectRepository Projects { get; }
        EmployeeProjectRepository EmployeeProjects { get; }
        void Save();
        Task SaveAsync();
    }
}
