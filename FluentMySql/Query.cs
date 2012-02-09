using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMySql.Validation;

namespace FluentMySql
{
    public static class Query
    {
        public static SelectQuery Select(params object[] selectExpressions)
        {
            return new SelectQuery().Select(selectExpressions);
        }
    }
}
