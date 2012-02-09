using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentMySql.Utils
{
    public static class Objects
    {
        private static Regex objectExpression = new Regex(@"^(\w*|`\w*`)\z", RegexOptions.Compiled);

        public static bool IsValidObject(string sqlObject)
        {
            return objectExpression.IsMatch(sqlObject);
        }

        public static bool IsValidQualifiedObject(string sqlObject)
        {
            return sqlObject.Split('.').All(obj => IsValidObject(obj));
        }

        public static string TrimObject(string sqlObject)
        {
            if (sqlObject == null)
                return null;
            return sqlObject.Replace("`", "");
        }
    }
}
