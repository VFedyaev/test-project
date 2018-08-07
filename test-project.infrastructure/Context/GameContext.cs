using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testproject.core.Entities;

namespace testproject.infrastructure.Context
{
    public class GameContext : DbContext
    {
        public GameContext()
           : base("name=GameContext")
        {
            var a = Database.Connection.ConnectionString;
        }

        public GameContext(string connectionString) : base(connectionString) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    }
}
