using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testproject.core.Entities;
using testproject.core.Interfaces;
using testproject.infrastructure.Context;
using X.PagedList;

namespace testproject.infrastructure.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private GameContext db;

        public ProjectRepository(GameContext context) => db = context;

        public void Create(Project item) => db.Projects.Add(item);

        public void Delete(Guid id)
        {
            Project project = Get(id);
            if (project != null)
                db.Projects.Remove(project);
        }

        public Project Get(Guid id) => db.Projects.Find(id);

        public IEnumerable<Project> GetAll() => db.Projects;

        public IPagedList<Project> GetAllIndex(int pageNumber, int pageSize, string search) => db.Projects.Include(e => e.EmployeeProjects)
            .Where(x => x.Name.Contains(search) || search == null).OrderBy(x => x.Name).ToPagedList(pageNumber, pageSize);

        public async Task<Project> GetAsync(Guid? id) => await db.Projects.FindAsync(id);

        public void Update(Project item) => db.Entry(item).State = EntityState.Modified;
    }
}
