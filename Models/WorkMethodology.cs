using System;
using System.Collections.Generic;
namespace Models
{
    public class WorkMethodology
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}
