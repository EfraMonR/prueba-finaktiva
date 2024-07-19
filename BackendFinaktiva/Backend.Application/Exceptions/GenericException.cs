using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Exceptions
{
    public class GenericException
    {
        public ValidationResult CrearExcepcion(string code, string error)
        {
            ValidationResult validationResult = new ValidationResult();
            validationResult.Errors = new List<ValidationFailure>
            {
                new ValidationFailure { ErrorCode = code, ErrorMessage = error }
            };

            return validationResult;
        }
    }
}
