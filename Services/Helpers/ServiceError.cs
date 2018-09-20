using System;
using System.Collections.Generic;

namespace Services.Helpers
{
    public class ServiceError
    {
        private readonly Dictionary<string, string> _errorMessages;

        public bool Error { get => _errorMessages.Count > 0; }

        public ServiceError()
        {
            _errorMessages = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get 
            {
                if (_errorMessages.ContainsKey(key))
                    return _errorMessages[key];

                return "";
            }
        }
    }
}
