using System;
using Models;
using SharedLibraries.Errors;
using SharedLibraries.Errors.Interfaces;
using Validators.Interfaces;

namespace Validators
{
    public class PersonValidator : Validator, IPersonValidator
    {
        public PersonValidator()
        {
            GetErrorDescriptionFunc = getErrorDescription;
        }
        
        public IValidationResult Validate(Person data)
        {
            if(data == null)
                throw new ArgumentNullException(nameof(data));
            
            validateDni(data.Dni);
            validateName(data.FirstName, data.LastName);
            validateAge(data.Age);
            
            return this;
        }

        private void validateDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                AddError((int)PersonError.DniEmpty);
        }

        private void validateName(string firstname, string lastname)
        {
            if (string.IsNullOrWhiteSpace(firstname))
                AddError((int) PersonError.FirstnameEmpty);
            if (string.IsNullOrWhiteSpace(lastname))
                AddError((int) PersonError.LastnameEmpty);
        }

        private void validateAge(int age)
        {
            if (age < 0)
                AddError((int) PersonError.NegativeAge);
        }
        
        private string getErrorDescription(int error)
        {
            switch (error)
            {
                case (int)PersonError.DniEmpty:
                    return "DNI can't be empty";
                case (int)PersonError.FirstnameEmpty:
                    return "Firstname can't be empty";
                case (int)PersonError.LastnameEmpty:
                    return "Lastname can't be empty";
                case (int)PersonError.NegativeAge:
                    return "Age can't be negative";
                default:
                    throw new ArgumentOutOfRangeException(nameof(error), error, null);
            }
        }
    }
}