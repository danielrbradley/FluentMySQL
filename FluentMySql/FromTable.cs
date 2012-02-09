using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FluentMySql.Core;

namespace FluentMySql
{
    public class FromTable : IFromExpression
    {
        public FromTable(params string[] tableReferencePath)
            : this(new QualifiedName(tableReferencePath))
        {
        }

        public FromTable(QualifiedName table)
        {
            this.table = table;
        }

        private QualifiedName table;

        public QualifiedName Table
        {
            get
            {
                return table;
            }
        }

        public string BuildSql()
        {
            return string.Format("FROM {0}", this.table.BuildSql());
        }

        public FromTable Clone()
        {
            return (FromTable)this.MemberwiseClone();
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
