using System;
using System.Collections.Generic;
using DataAccess.Repository.Interfaces;
using Models;
using Services.Helpers;
using Services.Interfaces;
using System.Linq;
using SharedLibraries.Errors.Interfaces;
using Validators.Interfaces;

namespace Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IProjectValidator _validator;

        public ProjectService(IProjectRepository repository, IProjectValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public event EventHandler<IValidationResult> NotifyError;

        public bool Create(Project item)
        {
            if (item == null)
                throw new InvalidOperationException("The item can't be null");

            var created = false;
            var validationResult = _validator.Validate(item);
            if (validationResult.HasError)
                NotifyError?.Invoke(this, validationResult);
            else
                created = _repository.Create(item);

            return created;
        }

        public bool Delete(Project item)
        {
            if (item == null)
                throw new InvalidOperationException("The item can't be null");

            return _repository.Delete(item);
        }

        public IEnumerable<Project> GetBetweenDates(DateTime dateOne, DateTime dateTwo)
        {
            if (dateOne > dateTwo)
                throw new InvalidOperationException("Invalid, dateOne can't be greater than dateTwo");

            return _repository.GetBetweenDates(dateOne, dateTwo);
        }

        public IEnumerable<Project> GetByCompany(string companyCif)
        {
            if (string.IsNullOrWhiteSpace(companyCif))
                throw new InvalidOperationException("The companyCif can't be null or empty");

            return _repository.GetByCompany(companyCif);
        }

        public IEnumerable<Project> GetByCreationDate(DateTime creationDate)
        {
            return _repository.GetByCreationDate(creationDate);
        }

        public Project GetById(Guid id)
        {
            if (id == null)
                throw new InvalidOperationException("Id can't be null");

            return _repository.GetById(id);
        }

        public IEnumerable<Project> GetByLaunchDate(DateTime launchDate)
        {
            return _repository.GetByLaunchDate(launchDate);
        }

        public IEnumerable<Project> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("The name can't be null or empty");

            return _repository.GetByName(name);
        }

        public IEnumerable<Project> GetByWorkMethodology(string workMethodologyCode)
        {
            if (string.IsNullOrWhiteSpace(workMethodologyCode))
                throw new InvalidOperationException("The workMethodologyCode can't be null or empty");

            return _repository.GetByWorkMethodology(workMethodologyCode);
        }

        public IEnumerable<Project> GetList()
        {
            return _repository.Get().ToArray();
        }

        public bool Update(Project item)
        {
            if (item == null)
                throw new InvalidOperationException("The item can't be null");

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
