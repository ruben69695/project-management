using System;
using Models;
using SharedLibraries.Errors;
using SharedLibraries.Errors.Interfaces;
using Validators.Interfaces;

namespace Validators
{
    public class ProjectValidator : Validator, IProjectValidator
    {
        public ProjectValidator()
        {
            GetErrorDescriptionFunc = getErrorDescription;
        }
        
        public IValidationResult Validate(Project data)
        {
            validateName(data.Name);

            return this;
        }

        private void validateName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                AddError((int) ProjectError.EmptyName);
        }

        private string getErrorDescription(int error)
        {
            switch (error)
            {
                case (int) ProjectError.EmptyName:
                    return "Project name can't be empty";
                default:
                    throw new ArgumentOutOfRangeException(nameof(error), error, null);
            }
        }
    }
}