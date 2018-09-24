using System;
using System.Collections.Generic;

namespace Models
{
    public class Task
    {
        public virtual Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual Project Project { get; set; }
        public virtual List<Person> AssignedPersons { get; set; }
        public virtual TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        Pending = 0,
        Done = 1
    }
}
