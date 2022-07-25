﻿using FluentValidation.Results;

namespace Nutri.Application.Exceptions
{
    public class ValidationException:ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException():base("Se presentaron uno ó mas errores de validacion.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(x=>x.PropertyName, x=> x.ErrorMessage)
                .ToDictionary(failureGroup=>failureGroup.Key, failureGroup =>failureGroup.ToArray());
        }

    }
}
