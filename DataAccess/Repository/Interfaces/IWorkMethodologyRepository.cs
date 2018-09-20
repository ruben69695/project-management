using System;
using System.Linq;

using Models;
namespace DataAccess.Repository.Interfaces
{
    public interface IWorkMethodologyRepository : IRepository<WorkMethodology>
    {
        WorkMethodology GetByCode(string code);
    }
}
