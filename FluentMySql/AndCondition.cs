using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql
{
    public class AndCondition : ICondition
    {
        public AndCondition(ICondition left, ICondition right)
        {
            if (left == null)
                throw new ArgumentNullException("left", "left condition is null.");
            if (right == null)
                throw new ArgumentNullException("right", "right condition is null.");

            this.left = left;
            this.right = right;
        }

        private ICondition left, right;

        public ICondition Left
        {
            get
            {
                return left;
            }
        }

        public ICondition Right
        {
            get
            {
                return right;
            }
        }

        public string BuildSql()
        {
            return string.Format("{0} AND {1}", this.Left.BuildSql(), this.Right.BuildSql());
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
