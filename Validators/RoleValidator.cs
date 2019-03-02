using System;
using Models;
using SharedLibraries.Errors;
using SharedLibraries.Errors.Interfaces;
using Validators.Interfaces;

namespace Validators
{
    public class RoleValidator : Validator, IRoleValidator
    {
        public RoleValidator()
        {
            GetErrorDescriptionFunc = getErrorDescription;
        }

        public IValidationResult Validate(Role data)
        {
            validateCode(data.Code);
            validateName(data.Name);

            return this;
        }

        private void validateCode(string code)
        {
            if(string.IsNullOrWhiteSpace(code))
                AddError((int) RoleError.EmptyCode);
        }

        private void validateName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                AddError((int) RoleError.EmptyName);
        }
        
        private string getErrorDescription(int error)
        {
            switch (error)
            {
                case (int) RoleError.EmptyCode:
                    return "The code can't be empty";
                case (int) RoleError.EmptyName:
                    return "The name can't be empty";
                default:
                    throw new ArgumentOutOfRangeException(nameof(error), error, null);
            }
        }
        
    }
}