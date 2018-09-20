using System;
using System.Collections.Generic;

namespace Models
{
    public class Role
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Person> Persons { get; set; }
    }
}
