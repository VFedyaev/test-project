using Sibers.BLL.Repositories;
using System;
using System.Threading.Tasks;

namespace Sibers.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        EmployeeRepository Employees { get; }
        ProjectRepository Projects { get; }
        void Save();
        Task SaveAsync();
    }
}
