using Sibers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        
        public ApplicationContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().HasMany(c => c.Employees)
                .WithMany(s => s.Projects)
                .Map(t => t.MapLeftKey("PId") // project
                .MapRightKey("EId") // employee
                .ToTable("ProjectEmployee"));
        }

        public System.Data.Entity.DbSet<Sibers.WEB.Models.ProjectViewModel> ProjectViewModels { get; set; }

        public System.Data.Entity.DbSet<Sibers.WEB.Models.EmployeeViewModel> EmployeeViewModels { get; set; }
    }
}

