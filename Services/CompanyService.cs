using System;
using Services.Interfaces;
using Models;
using Services.Helpers;
using DataAccess.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _dataAccess;

        public CompanyService(ICompanyRepository repository)
        {
            _dataAccess = repository;
        }

        public event EventHandler<ServiceError> NotifyError;

        public bool Create(Company item)
        {
            if (item == null)
                throw new InvalidOperationException("The company can't be null");

            return _dataAccess.Create(item);
        }

        public bool Delete(Company item)
        {
            if (item == null)
                throw new InvalidOperationException("The company can't be null");

            return _dataAccess.Delete(item);
        }

        public IEnumerable<Company> GetList()
        {
            return _dataAccess.Get();
        }

        public Company GetByCif(string cif)
        {
            if (string.IsNullOrWhiteSpace(cif))
                throw new InvalidOperationException("The cif can't be null or empty");

            return _dataAccess.GetByCif(cif);
        }

        public IEnumerable<Company> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("The name can't be null or empty");

            return _dataAccess.GetByName(name);
        }

        public bool Update(Company item)
        {
            if (item == null)
                throw new InvalidOperationException("The company can't be null");

            return _dataAccess.Update(item);
        }
    }
}
