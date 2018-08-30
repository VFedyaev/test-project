using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Domain.Entities
{
    public class Employee
    {
        [Key]
        public Guid EId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
