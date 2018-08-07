using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testproject.core.Entities;
using testproject.core.Interfaces;
using testproject.infrastructure.Context;
using System.Data.Entity;
using X.PagedList;

namespace testproject.infrastructure.Repositories
{
    public class EmployeeProjectRepository : IRepository<EmployeeProject>
    {
        private GameContext db;

        public EmployeeProjectRepository(GameContext context) => db = context;

        public void Create(EmployeeProject item) => db.EmployeeProjects.Add(item);

        public void Delete(Guid id)
        {
            EmployeeProject employeeProject = Get(id);
            if (employeeProject != null)
                db.EmployeeProjects.Remove(employeeProject);
        }

        public EmployeeProject Get(Guid id) => db.EmployeeProjects.Find(id);

        public IEnumerable<EmployeeProject> GetAll() => db.EmployeeProjects.Include(x => x.Employee).Include(y => y.Project);

        public IPagedList<EmployeeProject> GetAllIndex(int pageNumber, int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeProject> GetAsync(Guid? id) => await db.EmployeeProjects.FindAsync(id);

        public void Update(EmployeeProject item) => db.Entry(item).State = EntityState.Modified;
    }
}
