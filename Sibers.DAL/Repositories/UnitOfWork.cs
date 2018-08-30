using Sibers.DAL.EF;
using Sibers.Domain.Entities;
using Sibers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaseRepository<Employee> employeeRepository;
        private BaseRepository<Project> projectRepository;
        private ApplicationContext context;
        public UnitOfWork(string connectionString)
        {
            context = new ApplicationContext(connectionString);
        }
        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new BaseRepository<Employee>(context);
                return employeeRepository;
            }
        }
        public IRepository<Project> Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new BaseRepository<Project>(context);
                return projectRepository;
            }
        }
        
        // Save
        public void Save()
        {
            context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        // Dispose
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
