using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql
{
    public class CustomSelectExpression : ISelectExpression
    {
        public CustomSelectExpression(string selectExpression)
        {
            if (selectExpression == null)
                throw new ArgumentNullException("selectExpression", "selectExpression is null");

            this.selectExpression = selectExpression;
        }

        private string selectExpression;

        public string SelectExpression
        {
            get
            {
                return selectExpression;
            }
        }

        public string BuildSql()
        {
            return selectExpression;
        }

        public CustomSelectExpression Clone()
        {
            return this.MemberwiseClone() as CustomSelectExpression;
        }

        string IQuery.BuildSql()
        {
            return this.BuildSql();
        }

        ISelectExpression ISelectExpression.Clone()
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
