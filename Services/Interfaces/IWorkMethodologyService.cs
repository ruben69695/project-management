using System;
using Models;
using Services.Helpers.Interfaces;
namespace Services.Interfaces
{
    public interface IWorkMethodologyService : IMainService<WorkMethodology>, IErrorNotifier
    {
        WorkMethodology GetByCode(string code);
    }
}
