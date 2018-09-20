using System;
using DataAccess.Repository.Interfaces;
using Models;
using System.Linq;
using System.Collections.Generic;
namespace DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public Company GetByCif(string cif)
        {
            return base.Get().FirstOrDefault(x => x.Cif == cif);
        }

        public IList<Company> GetByName(string name)
        {
            return base.Get().Where(c => c.Name == name).ToList();
        }
    }
}
