using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentMySql
{
    public partial class SelectQuery
    {
        private ICondition whereCondition;

        public ICondition WhereCondition
        {
            get
            {
                return whereCondition;
            }
        }

        public SelectQuery Where(string condition)
        {
            return this.Where(new CustomCondition(condition));
        }

        public SelectQuery Where(ICondition condition)
        {
            if (condition == null)
                throw new ArgumentNullException("condition", "condition is null.");
            if (this.whereCondition != null)
                throw new InvalidOperationException("Where condition already set.");

            var query = this.Clone();
            query.whereCondition = condition;
            return query;
        }

        public SelectQuery And(string condition)
        {
            return this.And(new CustomCondition(condition));
        }

        public SelectQuery And(ICondition condition)
        {
            if (condition == null)
                throw new ArgumentNullException("condition", "condition is null.");

            var query = this.Clone();
            query.whereCondition = new AndCondition(query.whereCondition, condition);
            return query;
        }
    }
}
