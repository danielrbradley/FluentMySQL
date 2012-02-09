using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql
{
    public partial class SelectQuery
    {
        private IFromExpression fromTableReference;

        public IFromExpression FromTableReference
        {
            get
            {
                return fromTableReference;
            }
        }

        public SelectQuery From(params string[] tableReferencePath)
        {
            if (this.fromTableReference != null)
                throw new InvalidOperationException("FromTableReference is already set.");

            var query = this.Clone();
            query.fromTableReference = new FromTable(tableReferencePath);
            return query;
        }
    }
}
