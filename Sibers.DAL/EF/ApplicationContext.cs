using Sibers.DAL.Entities;
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
        public ApplicationContext()
           : base("name=ApplicationContext")
        {
            var a = Database.Connection.ConnectionString;
        }
        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new DbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasMany(c => c.Employees)
                .WithMany(s => s.Projects)
                .Map(t => t.MapLeftKey("Id") // project
                .MapRightKey("Id") // employee
                .ToTable("ProjectEmployee"));
        }
    }
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            Employee s1 = new Employee { Id = Guid.NewGuid(), FirstName = "Егор", LastName = "Иванов" };
            Employee s2 = new Employee { Id = Guid.NewGuid(), FirstName = "Мария", LastName = "Васильева" };
            Employee s3 = new Employee { Id = Guid.NewGuid(), FirstName = "Олег", LastName = "Кузнецов" };
            Employee s4 = new Employee { Id = Guid.NewGuid(), FirstName = "Ольга", LastName = "Петрова" };

            context.Employees.Add(s1);
            context.Employees.Add(s2);
            context.Employees.Add(s3);
            context.Employees.Add(s4);

            Project c1 = new Project
            {
                Id = Guid.NewGuid(),
                ProjectName = "Операционные системы",
                Employees = new List<Employee>() { s1, s2, s3 }
            };
            
            context.Projects.Add(c1);
            

            base.Seed(context);
        }
    }
}

