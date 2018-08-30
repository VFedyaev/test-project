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
    public class EmployeeDTO
    {
        [Key]
        public Guid EId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
