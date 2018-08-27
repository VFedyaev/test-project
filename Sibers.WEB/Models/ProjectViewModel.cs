using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sibers.WEB.Models
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}