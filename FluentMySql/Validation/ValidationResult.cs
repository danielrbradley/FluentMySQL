using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql.Validation
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            errors = new List<ValidationError>();
            byField = new Dictionary<string, List<ValidationError>>();
        }

        private List<ValidationError> errors;
        private Dictionary<string, List<ValidationError>> byField;

        public IList<ValidationError> Errors
        {
            get
            {
                return this.errors.AsReadOnly();
            }
        }

        public IList<ValidationError> this[string field]
        {
            get
            {
                if (!this.byField.ContainsKey(field))
                    return new List<ValidationError>(0).AsReadOnly();

                return this.byField[field].AsReadOnly();
            }
        }

        public bool IsValid
        {
            get
            {
                return this.errors.Count == 0;
            }
        }

        public void AddError(string field, string message)
        {
            this.AddError(new ValidationError(field, message));
        }

        public void AddError(string field, string message, params object[] messageArgs)
        {
            this.AddError(new ValidationError(field, message, messageArgs));
        }

        public void AddError(ValidationError error)
        {
            this.errors.Add(error);
            if (!byField.ContainsKey(error.Field))
                byField.Add(error.Field, new List<ValidationError>());
            byField[error.Field].Add(error);
        }
    }
}
