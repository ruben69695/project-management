using System;
using System.Collections.Generic;
using Models;
namespace DataAccess.Repository.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company GetByCif(string cif);
        IList<Company> GetByName(string name);
    }
}
