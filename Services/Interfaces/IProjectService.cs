using System;
using System.Collections.Generic;
using Models;
using Services.Helpers.Interfaces;
namespace Services.Interfaces
{
    public interface IProjectService : IMainService<Project>, IErrorNotifier
    {
        Project GetById(Guid id);
        IEnumerable<Project> GetByName(string name);
        IEnumerable<Project> GetByCompany(string companyCif);
        IEnumerable<Project> GetByWorkMethodology(string workMethodologyCode);
        IEnumerable<Project> GetByCreationDate(DateTime creationDate);
        IEnumerable<Project> GetByLaunchDate(DateTime launchDate);
        IEnumerable<Project> GetBetweenDates(DateTime dateOne, DateTime dateTwo);
    }
}
