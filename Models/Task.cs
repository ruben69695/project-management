using System;
namespace Models
{
    public class Task
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        //public virtual Company AssignedCompany { get; set; } // Redundant from project
        public virtual Project Project { get; set; }
        public virtual Person PersonAssigned { get; set; }
    }
}
