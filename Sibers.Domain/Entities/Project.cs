using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Domain.Entities
{
    public class Project
    {
        [Key]
        public Guid PId { get; set; }
        public string ProjectName { get; set; }
        public string Customer { get; set; }
        public string Perfomer { get; set; }
        public Guid? ManagerId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
