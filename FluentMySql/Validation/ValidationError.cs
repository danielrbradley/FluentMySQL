using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql.Validation
{
    public class ValidationError
    {
        public ValidationError(string field, string message)
        {
            this.Field = field;
            this.Message = message;
        }

        public ValidationError(string field, string message, params object[] messageArgs)
        {
            this.Field = field;
            this.Message = string.Format(message, messageArgs);
        }

        public string Field { get; private set; }
        public string Message { get; private set; }
    }
}
