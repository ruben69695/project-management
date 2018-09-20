using System;
using System.Collections.Generic;

namespace Models
{
    public class Sex
    {
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Person> Persons { get; set; }
    }
}
