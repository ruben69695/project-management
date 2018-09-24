using System;
using System.Collections.Generic;
namespace Models
{
    public class Project
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public virtual Company Company { get; set; }
        public virtual WorkMethodology WorkMethodology { get; set; } = null;
        public virtual DateTime? LaunchDate { get; set; } = null;
        public virtual DateTime? LastUpdate { get; set; } = null;
        public virtual List<Person> AssignedPersons { get; set; }
        public virtual List<Task> Tasks { get; set; }

    }
}
