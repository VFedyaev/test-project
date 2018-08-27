using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.DAL.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public Project()
        {
            Employees = new List<Employee>();
        }
    }
}
