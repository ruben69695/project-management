using SharedLibraries.Errors.Interfaces;

namespace Validators.Helpers.Interfaces
{
    public interface IValidable<in T>
    {
        IValidationResult Validate(T data);
    }
}