using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testproject.infrastructure.Context;
using testproject.infrastructure.Repositories;

namespace testproject.infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private GameContext db;

      //  private EmployeeProjectRepository employeeProjectRepository;
        private EmployeeRepository employeeRepository;
        private ProjectRepository projectRepository;


        public UnitOfWork()
        {
            db = new GameContext();
        }

        public UnitOfWork(string connectionString)
        {
            db = new GameContext(connectionString);
        }

        //public EmployeeProjectRepository EmployeeProjects
        //{
        //    get
        //    {
        //        if (employeeProjectRepository == null)
        //            employeeProjectRepository = new EmployeeProjectRepository(db);
        //        return employeeProjectRepository;
        //    }
        //}

        public EmployeeRepository Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }

        public ProjectRepository Projects {
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
