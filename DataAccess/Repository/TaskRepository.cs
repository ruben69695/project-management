using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DataAccess.Repository.Interfaces;
using Models;

namespace DataAccess.Repository
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public Models.Task GetById(Guid id)
        {
            return base.Get().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Models.Task> GetByOpenFilter(Func<Models.Task, bool> openFilter)
        {
            return base.Get().Where(openFilter);
        }

        public IEnumerable<Models.Task> GetByPerson(string personDni)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> GetByProject(Guid projectId)
        {
            return base.Get().Where(x => x.Project.Id == projectId);
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
