using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Repository.Interfaces;
using Models;

namespace DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public IEnumerable<Project> GetBetweenDates(DateTime dateOne, DateTime dateTwo)
        {
            return base.Get().Where(x => x.CreationDate >= dateOne && x.CreationDate <= dateTwo).ToList();
        }

        public IEnumerable<Project> GetByCompany(string companyCif)
        {
            return base.Get().Where(x => x.Company.Cif == companyCif).ToList();
        }

        public IEnumerable<Project> GetByCreationDate(DateTime creationDate)
        {
            return base.Get().Where(x => x.CreationDate == creationDate).ToList();
        }

        public Project GetById(Guid id)
        {
            return base.Get().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Project> GetByLaunchDate(DateTime launchDate)
        {
            return base.Get().Where(x => x.LaunchDate == launchDate);
        }

        public IEnumerable<Project> GetByName(string name)
        {
            return base.Get().Where(x => x.Name == name).ToList();
        }

        public IEnumerable<Project> GetByWorkMethodology(string workMethodologyCode)
        {
            return base.Get().Where(x => x.WorkMethodology.Code == workMethodologyCode).ToList();
        }
    }
}
