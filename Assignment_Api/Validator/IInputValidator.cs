using Assignment_Api.Exceptions;
using System.Collections.Generic;

namespace Assignment_Api.Validator
{
    public interface IInputValidator
    {
        public bool ValidateGuid(string id, out List<Error> errors);

        public bool ValidatedName(List<string> name, out List<Error> errors);
    }
}