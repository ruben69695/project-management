using System;
using System.Collections.Generic;

namespace Models
{
    public class Company
    {
        public virtual string Cif { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Person> Employees { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}
