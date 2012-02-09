using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentMySql
{
    internal class SelectExpressionList : List<ISelectExpression>, IQuery
    {
        public SelectExpressionList()
            : base()
        {
        }

        public SelectExpressionList(params object[] selectExpressions)
            : base()
        {
            if (selectExpressions.Length == 0)
                return;

            for (int i = 0; i < selectExpressions.Length; i++)
            {
                var selectExpression = selectExpressions[i];
                if (selectExpression == null)
                    throw new ArgumentNullException(string.Format("selectExpressions[{0}]", i), "selectExpression is null.");

                var type = selectExpression.GetType();
                if (type == typeof(string))
                    this.Add(SelectExpression.ParseSelectExpression((string)selectExpression));
                else if (type.IsSubclassOf(typeof(ISelectExpression)))
                    this.Add((ISelectExpression)selectExpression);
                else
                    throw new ArgumentException("Select expression not a string or ISelectExpression.", string.Format("selectExpressions[{0}]", i));
            }
        }

        public string BuildSql()
        {
            var builder = new StringBuilder("SELECT ");
            builder.Append(string.Join(", ", this.Select(se => se.BuildSql())));
            return builder.ToString();
        }

        public SelectExpressionList Clone()
        {
            var selectExpressionList = new SelectExpressionList();
            selectExpressionList.AddRange(this.Select(se => se.Clone()).ToList());
            return selectExpressionList;
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
