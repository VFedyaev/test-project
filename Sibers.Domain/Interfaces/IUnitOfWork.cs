using Sibers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Sibers.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }
        IRepository<Project> Projects { get; }
        Task SaveAsync();
        void Save();
    }
}
