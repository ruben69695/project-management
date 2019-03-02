using System;
using System.Collections.Generic;

namespace Services.Helpers
{
    public class ServiceError
    {
        private readonly Dictionary<int, string> _errorMessages;

        public bool HasError => _errorMessages.Count > 0;

        public ServiceError()
        {
            _errorMessages = new Dictionary<int, string>();
        }

        private ServiceError(ServiceError oldError, int newNumError, string newErrorDescription)
        {
            _errorMessages = oldError._errorMessages;
            _errorMessages.Add(newNumError, newErrorDescription);
        }

        public string this[int key]
        {
            get 
            {
                if (_errorMessages.ContainsKey(key))
                    return _errorMessages[key];

                return "";
            }
        }

        public ServiceError AddError(int numError, string description)
        {
            return new ServiceError(this, numError, description);
        }
    }
}
