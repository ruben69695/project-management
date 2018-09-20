using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Repository.Interfaces;
using Models;
using Services.Helpers;
using Services.Interfaces;

namespace Services
{
    public class WorkMethodologyService : IWorkMethodologyService
    {
        private readonly IWorkMethodologyRepository _dataAccess;

        public WorkMethodologyService(IWorkMethodologyRepository repository)
        {
            _dataAccess = repository;
        }

        public event EventHandler<ServiceError> NotifyError;

        public bool Create(WorkMethodology item)
        {
            if (item == null)
                throw new InvalidOperationException("The item can't be null");

            return _dataAccess.Create(item);
        }

        public bool Delete(WorkMethodology item)
        {
            if (item == null)
                throw new InvalidOperationException("The item can't be null");

            return _dataAccess.Delete(item);
        }

        public WorkMethodology GetByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new InvalidOperationException("The code can't be null or empty");

            return _dataAccess.GetByCode(code);
        }

        public IEnumerable<WorkMethodology> GetList()
        {
            return _dataAccess.Get().ToArray();
        }

        public bool Update(WorkMethodology item)
        {
            if (item == null)
                throw new InvalidOperationException("The item can't be null");

            return _dataAccess.Update(item);
        }
    }
}
