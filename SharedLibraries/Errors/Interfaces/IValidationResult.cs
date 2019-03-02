using System.Collections.Generic;

namespace SharedLibraries.Errors.Interfaces
{
    public interface IValidationResult
    {
        Dictionary<int, string> ErrorMessages { get; }
        bool HasError { get; }
    }
}