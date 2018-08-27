using Sibers.BLL.Interfaces;
using Sibers.DAL.EF;
using Sibers.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Sibers.BLL.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private ApplicationContext db;

        public ProjectRepository(ApplicationContext context) => db = context;

        public void Create(Project item) => db.Projects.Add(item);

        public void Delete(Guid id)
        {
            Project project = Get(id);
            if (project != null)
                db.Projects.Remove(project);
        }

        public Project Get(Guid id) => db.Projects.Find(id);

        public IEnumerable<Project> GetAll() => db.Projects;

        public IPagedList<Project> GetAllIndex(int pageNumber, int pageSize, string search) => db.Projects
            .Where(x => x.ProjectName.Contains(search) || search == null).OrderBy(x => x.ProjectName).ToPagedList(pageNumber, pageSize);

        public async Task<Project> GetAsync(Guid? id) => await db.Projects.FindAsync(id);

        public void Update(Project item) => db.Entry(item).State = EntityState.Modified;
    }
}

