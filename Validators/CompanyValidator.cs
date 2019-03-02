using System;
using Models;
using SharedLibraries.Errors;
using SharedLibraries.Errors.Interfaces;
using Validators.Interfaces;

namespace Validators
{
    public class CompanyValidator : Validator, ICompanyValidator
    {
        public CompanyValidator()
        {
            GetErrorDescriptionFunc = getErrorDescription;
        }
        
        public IValidationResult Validate(Company data)
        {
            if(data == null)
                throw new ArgumentNullException(nameof(data));
            
            validateCif(data.Cif);
            validateName(data.Name);

            return this;
        }

        private void validateCif(string cif)
        {
            if(string.IsNullOrWhiteSpace(cif))
                AddError((int) CompanyError.EmptyCif);
        }

        private void validateName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                AddError((int) CompanyError.EmptyName);
        }

        private string getErrorDescription(int error)
        {
            switch (error)
            {
                case (int)CompanyError.EmptyCif:
                    return "Cif can't be empty";
                case (int) CompanyError.EmptyName:
                    return "Name can't be empty";
                default:
                    throw new ArgumentOutOfRangeException(nameof(error), error, null);
            }
        }
        
    }
}