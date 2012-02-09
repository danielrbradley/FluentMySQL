using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentMySql
{
    public class Param : IQuery
    {
        public Param(object value)
            : this(null, value)
        {
        }

        public Param(string name, object value)
        {
            if (name != null && !Param.IsParamValid(name))
                throw new FormatException("Param name is invalid.");

            this.name = name;
            this.value = value;
        }

        private static Regex paramNameValidation = new Regex("\A[A-Za-z0-9]+\z", RegexOptions.Compiled);

        public static bool IsParamValid(string name)
        {
            return paramNameValidation.IsMatch(name);
        }

        private string name;
        private object value;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public object Value
        {
            get
            {
                return value;
            }
        }

        public string BuildSql()
        {
            throw new NotImplementedException();
        }

        public Param Clone()
        {
            return (Param)this.MemberwiseClone();
        }

        IQuery IQuery.Clone()
        {
            return this.Clone();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
