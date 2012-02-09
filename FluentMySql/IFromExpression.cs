using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql
{
    public interface IFromExpression : IQuery
    {
        new IFromExpression Clone();
    }
}
