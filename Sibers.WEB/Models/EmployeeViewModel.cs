using Sibers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sibers.WEB.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public Guid EId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}