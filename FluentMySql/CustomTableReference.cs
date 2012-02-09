using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql
{
    public class CustomTableReference : IFromExpression
    {
        public CustomTableReference(string tableReference)
        {
            if (tableReference == null)
                throw new ArgumentNullException("tableReference", "tableReference is null");

            this.tableReference = tableReference;
        }

        private string tableReference;

        public string TableReference
        {
            get
            {
                return tableReference;
            }
        }

        public string BuildSql()
        {
            return tableReference;
        }

        public CustomTableReference Clone()
        {
            return (CustomTableReference)this.MemberwiseClone();
        }

        string IQuery.BuildSql()
        {
            return this.BuildSql();
        }

        IFromExpression IFromExpression.Clone()
        {
            return this.Clone();
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
