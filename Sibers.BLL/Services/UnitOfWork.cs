using Sibers.BLL.Interfaces;
using Sibers.BLL.Repositories;
using Sibers.DAL.EF;
using System;
using System.Threading.Tasks;

namespace Sibers.BLL.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private EmployeeRepository employeeRepository;
        private ProjectRepository projectRepository;


        public UnitOfWork()
        {
            db = new ApplicationContext();
        }

        public UnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
        }


        public EmployeeRepository Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public ProjectRepository Projects
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(db);
                return projectRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
