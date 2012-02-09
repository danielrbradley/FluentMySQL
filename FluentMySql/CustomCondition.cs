using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql
{
    public class CustomCondition : ICondition
    {
        public CustomCondition(string condition)
        {
            if (condition == null)
                throw new ArgumentNullException("condition", "condition is null.");

            this.condition = condition;
        }

        private string condition;

        public string Condition
        {
            get
            {
                return condition;
            }
        }

        public string BuildSql()
        {
            return this.Condition;
        }

        public CustomCondition Clone()
        {
            return (CustomCondition)this.MemberwiseClone();
        }

        ICondition ICondition.Clone()
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
