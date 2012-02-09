using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentMySql
{
    public partial class SelectQuery
    {
        public SelectQuery Select(params object[] selectExpressions)
        {
            if (selectExpressions.Length == 0)
                return this;

            var parsedExpressions = new SelectExpressionList(selectExpressions);

            var query = this.Clone();
            if (query.selectExpressions == null)
                query.selectExpressions = parsedExpressions;
            else
                query.selectExpressions.AddRange(parsedExpressions);

            return query;
        }
    }
}
