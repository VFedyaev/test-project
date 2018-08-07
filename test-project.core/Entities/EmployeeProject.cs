using System;

namespace testproject.core.Entities
{
    public class EmployeeProject
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }
}