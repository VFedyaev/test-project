using System;
using System.Collections.Generic;

namespace testproject.core.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public Guid? EmployeeProjectId { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}