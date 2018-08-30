using Sibers.BLL.Interfaces;
using Sibers.DAL.EF;
using Sibers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Sibers.BLL.DTO
{
    public class ProjectDTO 
    {
        [Key]
        public Guid PId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}

