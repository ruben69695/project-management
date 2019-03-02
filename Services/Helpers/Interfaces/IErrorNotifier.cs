using System;
using Services.Helpers;
using SharedLibraries.Errors.Interfaces;

namespace Services.Helpers.Interfaces
{
    public interface IErrorNotifier
    {
        event EventHandler<IValidationResult> NotifyError;
    }
}
