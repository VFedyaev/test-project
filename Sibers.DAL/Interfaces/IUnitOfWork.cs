using Sibers.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace Sibers.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        EmployeeRepository Employees { get; }
        ProjectRepository Projects { get; }
        void Save();
        Task SaveAsync();
    }
}
