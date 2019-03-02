using System;
using Services.Interfaces;
using Models;
using Services.Helpers;
using DataAccess.Repository.Interfaces;
using System.Collections.Generic;
using SharedLibraries.Errors.Interfaces;
using Validators.Interfaces;

namespace Services
{   
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        private readonly ICompanyValidator _validator;

        public CompanyService(ICompanyRepository repository, ICompanyValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public event EventHandler<IValidationResult> NotifyError;

        public bool Create(Company item)
        {
            if (item == null)
                throw new InvalidOperationException("The company can't be null");

            var created = false;
            var validationResult = _validator.Validate(item);
            
            if(validationResult.HasError)
                NotifyError?.Invoke(this, validationResult);
            else
                created = _repository.Create(item);

            return created;
        }

        public bool Delete(Company item)
        {
            if (item == null)
                throw new InvalidOperationException("The company can't be null");

            return _repository.Delete(item);
        }

        public IEnumerable<Company> GetList()
        {
            return _repository.Get();
        }

        public Company GetByCif(string cif)
        {
            if (string.IsNullOrWhiteSpace(cif))
                throw new InvalidOperationException("The cif can't be null or empty");

            return _repository.GetByCif(cif);
        }

        public IEnumerable<Company> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("The name can't be null or empty");

            return _repository.GetByName(name);
        }

        public bool Update(Company item)
        {
            if (item == null)
                throw new InvalidOperationException("The company can't be null");

            var updated = false;
            var validationResult = _validator.Validate(item);

            if (validationResult.HasError)
                NotifyError?.Invoke(this, validationResult);
            else
                updated = _repository.Update(item);

            return updated;
        }
    }
}
