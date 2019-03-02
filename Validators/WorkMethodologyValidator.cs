using System;
using Models;
using SharedLibraries.Errors;
using SharedLibraries.Errors.Interfaces;
using Validators.Interfaces;

namespace Validators
{
    public class WorkMethodologyValidator : Validator, IWorkMethodologyValidator
    {
        public WorkMethodologyValidator()
        {
            GetErrorDescriptionFunc = getErrorDescription;
        }

        public IValidationResult Validate(WorkMethodology data)
        {
            validateCode(data.Code);
            validateName(data.Name);

            return this;
        }

        private void validateName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                AddError((int) WorkMethodologyError.EmptyName);
        }

        private void validateCode(string code)
        {
            if(string.IsNullOrWhiteSpace(code))
                AddError((int) WorkMethodologyError.EmptyCode);
        }
        
        private string getErrorDescription(int error)
        {
            switch (error)
            {
                case (int) WorkMethodologyError.EmptyCode:
                    return "Code can't be empty";
                default:
                    throw new ArgumentOutOfRangeException(nameof(error), error, null);
            }
        }
    }
}