using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using DataAccess.Repository.Interfaces;
using Models;
using Services.Interfaces;
using SharedLibraries.Errors.Interfaces;
using Validators.Interfaces;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IRoleValidator _validator;

        public RoleService(IRoleRepository repository, IRoleValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }
        
        public event EventHandler<IValidationResult> NotifyError;
        
        public bool Create(Role item)
        {
            if(item == null)
                throw new InvalidOperationException("item can't be null");

            var created = false;
            var validationResult = _validator.Validate(item);
            if (validationResult.HasError)
                NotifyError?.Invoke(this, validationResult);
            else
                created = _repository.Create(item);

            return created;
        }

        public IEnumerable<Role> GetList()
        {
            return _repository.Get();
        }

        public bool Update(Role item)
        {
            if(item == null)
                throw new InvalidOperationException("item can't be null");

            var updated = false;
            var validationResult = _validator.Validate(item);
            if (validationResult.HasError)
                NotifyError?.Invoke(this, validationResult);
            else
                updated = _repository.Update(item);

            return updated;
        }

        public bool Delete(Role item)
        {
            if(item == null)
                throw new InvalidOperationException("item can't be null");

            return _repository.Delete(item);
        }

        public Role GetByCode(string code)
        {
            if(string.IsNullOrEmpty(code))
                throw new InvalidOperationException("code can't be empty or null");
            
            return _repository.GetByCode(code);
        }
    }
}