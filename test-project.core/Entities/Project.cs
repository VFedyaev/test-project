using System;
using System.Collections.Generic;

namespace testproject.core.Entities
{
    public class Project
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid? EmployeeProjectId { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}