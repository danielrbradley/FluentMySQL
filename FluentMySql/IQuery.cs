using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql
{
    public interface IQuery : ICloneable
    {
        string BuildSql();
        new IQuery Clone();
    }
}
