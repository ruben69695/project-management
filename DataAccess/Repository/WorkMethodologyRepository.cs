using System;
using System.Linq;

using Models;
using DataAccess.Repository.Interfaces;
namespace DataAccess.Repository
{
    public class WorkMethodologyRepository : Repository<WorkMethodology>, IWorkMethodologyRepository
    {
        public WorkMethodology GetByCode(string code)
        {
            return base.Get().FirstOrDefault((wm) => wm.Code == code);
        }
    }
}
