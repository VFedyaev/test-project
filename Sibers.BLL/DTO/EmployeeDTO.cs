using Sibers.BLL.Interfaces;
using Sibers.DAL.EF;
using Sibers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Sibers.BLL.DTO
{
    public class EmployeeDTO
    {
        public Guid EId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
