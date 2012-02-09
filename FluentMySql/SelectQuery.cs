using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMySql.Validation;

namespace FluentMySql
{
    public partial class SelectQuery : ValidatedQuery, IQuery
    {
        private SelectExpressionList selectExpressions;
        private IFromExpression fromTableReference;

        public IList<ISelectExpression> SelectExpressions
        {
            get
            {
                return selectExpressions.AsReadOnly();
            }
        }

        public IFromExpression FromTableReference
        {
            get
            {
                return fromTableReference;
            }
        }

        public string BuildSql()
        {
            if (!this.IsValid)
                throw new InvalidOperationException("Cannot build SQL while query is invalid.");

            var builder = new StringBuilder();
            builder.Append(this.selectExpressions.BuildSql());
            builder.Append(" ");
            builder.Append(this.fromTableReference.BuildSql());
            builder.Append(";");
            return builder.ToString();
        }

        public override ValidationResult Validate()
        {
            var result = new ValidationResult();
            return result;
        }

        public SelectQuery Clone()
        {
            return new SelectQuery()
            {
                selectExpressions = this.selectExpressions != null ? this.selectExpressions.Clone() : null,
                fromTableReference = this.fromTableReference != null ? this.fromTableReference.Clone() : null,
            };
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
