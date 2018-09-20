using Models;
using Services.Helpers.Interfaces;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IPersonService : IMainService<Person>, IErrorNotifier
    {
        Person GetByDni(string dni);
        IList<Person> GetByFullName(string name, string lastName);
        IList<Person> GetByRole(Role role);
        IList<Person> GetByRole(string roleCode);
        IList<Person> GetByCompany(Company company);
        IList<Person> GetByCompany(string companyCif);
        IList<Person> GetByAge(int age);
        IList<Person> GetBySex(Sex sex);
        IList<Person> GetBySex(string sexCode);
    }
}
