using Assignment_Api.Exceptions;
using Assignment_Api.Helper;
using System.Collections.Generic;

namespace Assignment_Api.Validator
{
    public class InputValidator : IInputValidator
    {
        private static readonly char[] SpecialChars = Constants.Genric.SpecialCharacters.ToCharArray();

        public bool ValidateGuid(string id, out List<Error> errors)
        {
            if (!id.IsGuid())
            {
                errors = new List<Error>()
             {
                 new Error(Constants.Error.InValidGuid, "Given Input is not a valid guid")
             };
                return false;
            }
            errors = null;
            return true;
        }

        public bool ValidatedName(List<string> name, out List<Error> errors)
        {
            foreach (var nameItem in name)
            {
                int indexOf = nameItem.IndexOfAny(SpecialChars);
                if (indexOf != -1)
                {
                    errors = new List<Error>() { new Error(Constants.Error.InValidName, "Name cannot contain special characters ") };
                    return false;
                }
            }
            errors = null;
            return true;
        }
    }
}