using System;
using Models;
using System.Collections.Generic;
namespace DataAccess.Repository.Interfaces
{
	public interface ITaskRepository : IRepository<Task>
    {
        Task GetById(Guid id);
        IEnumerable<Task> GetByPerson(string personDni);
        IEnumerable<Task> GetByProject(Guid projectId);
        IEnumerable<Task> GetByProject(Guid projectId, string personDni);
        IEnumerable<Task> GetByProject(Guid projectId, string personDni, TaskStatus status);
        IEnumerable<Task> GetByOpenFilter(Func<Task, bool> openFilter);
    }
}
