using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace testproject.core.Entities
{
    public class Project
    {
        [Key]
        public Guid PId { get; set; } 
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public Project()
        {
            Employees = new List<Employee>();
        }
    }
}