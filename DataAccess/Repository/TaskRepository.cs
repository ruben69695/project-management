using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Repository.Interfaces;
using Models;

namespace DataAccess.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public Models.Task GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> GetByOpenFilter(Func<Models.Task, bool> openFilter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> GetByPerson(string personDni)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> GetByProject(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> GetByProject(Guid projectId, string personDni)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> GetByProject(Guid projectId, string personDni, Models.TaskStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
