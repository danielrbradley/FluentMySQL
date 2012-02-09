using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMySql.Validation;

namespace FluentMySql
{
    public partial class SelectQuery : ValidatedQuery, IQuery
    {
        public string BuildSql()
        {
            if (!this.IsValid)
                throw new InvalidOperationException("Cannot build SQL while query is invalid.");

            var builder = new StringBuilder();
            builder.Append(this.selectExpressions.BuildSql());
            builder.Append(" ");
            builder.Append(this.FromTableReference.BuildSql());
            if (this.WhereCondition != null)
            {
                builder.Append(" WHERE ");
                builder.Append(this.WhereCondition.BuildSql());
            }
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
                whereCondition = this.whereCondition != null ? this.whereCondition.Clone() : null,
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
