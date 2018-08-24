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
    public class EmployeeRepository : IRepository<Employee>
    {
        private GameContext db;

        public EmployeeRepository(GameContext context) => db = context;

        public void Create(Employee item) => db.Employees.Add(item);

        public void Delete(Guid id)
        {
            Employee employee = Get(id);
            if (employee != null)
                db.Employees.Remove(employee);
        }

        public Employee Get(Guid id) => db.Employees.Find(id);

        public IEnumerable<Employee> GetAll() => db.Employees;

        public IPagedList<Employee> GetAllIndex(int pageNumber, int pageSize, string search) => db.Employees.Where(emp => emp.FirstName.Contains(search) || search == null).
                                                                            OrderBy(n => n.FirstName).ToPagedList(pageNumber, pageSize);

        public async Task<Employee> GetAsync(Guid? id) => await db.Employees.FindAsync(id);

        public void Update(Employee item) => db.Entry(item).State = EntityState.Modified;
    }
}
