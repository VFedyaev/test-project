using Sibers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sibers.WEB.Models
{
    public class ProjectViewModel
    {
        [Key]
        public Guid PId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } 
    }
}