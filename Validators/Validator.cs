using System;
using System.Collections.Generic;
using System.Linq;
using SharedLibraries.Errors.Interfaces;

namespace Validators
{
    public abstract class Validator : IValidationResult
    {
        public Dictionary<int, string> ErrorMessages { get; }
        public bool HasError => ErrorMessages.Any();
        protected Func<int, string> GetErrorDescriptionFunc { private get; set; }

        protected Validator()
        {
            ErrorMessages = new Dictionary<int, string>();
        }

        protected void AddError(int errorNumber)
        {
            if (ErrorMessages.ContainsKey(errorNumber))
                throw new InvalidOperationException("This error number is already registered as an error");
            if (GetErrorDescriptionFunc == null)
                throw new NullReferenceException("GetErrorDescriptionFunc, " +
                                                 "this delegate needs to point to a function, to get the description errors");

            string errorDescription = GetErrorDescriptionFunc(errorNumber);
            
            ErrorMessages.Add(errorNumber, errorDescription);
        }

    }
}