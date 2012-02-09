using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMySql.Validation;

namespace FluentMySql
{
    public abstract class ValidatedQuery
    {
        public abstract ValidationResult Validate();

        public bool IsValid
        {
            get
            {
                return this.Validate().IsValid;
            }
        }
    }
}
