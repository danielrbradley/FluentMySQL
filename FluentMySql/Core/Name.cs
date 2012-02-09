using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql.Core
{
    public class Name : IQuery
    {
        public Name(string objectPath)
        {
            if (!Utils.Objects.IsValidObject(objectPath))
                throw new FormatException("Invalid object format.");

            this.value = objectPath.Trim('`');
        }

        private string value;

        public string Value
        {
            get
            {
                return value;
            }
        }

        public string BuildSql()
        {
            return string.Format("`{0}`", this.Value);
        }

        public Name Clone()
        {
            return (Name)this.MemberwiseClone();
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
