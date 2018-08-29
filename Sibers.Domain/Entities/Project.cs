using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.Domain.Entities
{
    public class Project
    {
        public Guid PId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
