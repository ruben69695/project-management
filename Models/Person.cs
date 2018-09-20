using System;
using System.Collections.Generic;
namespace Models
{
    public class Person
    {
        public virtual string Dni { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual Company Company { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Project> AssignedProjects { get; set; }
    }
}
