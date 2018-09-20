using System;
using System.Collections.Generic;
using DataAccess.Repository.Interfaces;
using Models;
using Services.Helpers;
using Services.Interfaces;
using System.Linq;
namespace Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _dataAccess;

        public ProjectService(IProjectRepository repository)
        {
            _dataAccess = repository;
        }

        public event EventHandler<ServiceError> NotifyError;

        public bool Create(Project item)
        {
            if (item == null)
                throw new InvalidOperationException("The item can't be null");

            return _dataAccess.Create(item);
        }

        public bool Delete(Project item)
        {
            if (item == null)
                throw new InvalidOperationException("The item can't be null");

            return _dataAccess.Delete(item);
        }

        public IEnumerable<Project> GetBetweenDates(DateTime dateOne, DateTime dateTwo)
        {
            if (dateOne > dateTwo)
                throw new InvalidOperationException("Invalid, dateOne can't be greater than dateTwo");

            return _dataAccess.GetBetweenDates(dateOne, dateTwo);
        }

        public IEnumerable<Project> GetByCompany(string companyCif)
        {
            if (string.IsNullOrWhiteSpace(companyCif))
                throw new InvalidOperationException("The companyCif can't be null or empty");

            return _dataAccess.GetByCompany(companyCif);
        }

        public IEnumerable<Project> GetByCreationDate(DateTime creationDate)
        {
            return _dataAccess.GetByCreationDate(creationDate);
        }

        public Project GetById(Guid id)
        {
            if (id == null)
                throw new InvalidOperationException("Id can't be null");

            return _dataAccess.GetById(id);
        }

        public IEnumerable<Project> GetByLaunchDate(DateTime launchDate)
        {
            return _dataAccess.GetByLaunchDate(launchDate);
        }

        public IEnumerable<Project> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException("The name can't be null or empty");

            return _dataAccess.GetByName(name);
        }

        public IEnumerable<Project> GetByWorkMethodology(string workMethodologyCode)
        {
            if (string.IsNullOrWhiteSpace(workMethodologyCode))
                throw new InvalidOperationException("The workMethodologyCode can't be null or empty");

            return _dataAccess.GetByWorkMethodology(workMethodologyCode);
        }

        public IEnumerable<Project> GetList()
        {
            return _dataAccess.Get().ToArray();
        }

        public bool Update(Project item)
        {
            if (item == null)
                throw new InvalidOperationException("The item can't be null");

            return _dataAccess.Update(item);
        }
    }
}
