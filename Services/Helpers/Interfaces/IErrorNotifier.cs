using System;
using Services.Helpers;
namespace Services.Helpers.Interfaces
{
    public interface IErrorNotifier
    {
        event EventHandler<ServiceError> NotifyError;
    }
}
