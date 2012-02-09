using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FluentMySql.Core;

namespace FluentMySql
{
    public class SelectExpression : ISelectExpression
    {
        public SelectExpression(string selection)
            : this(new QualifiedObject(selection))
        {
        }

        public SelectExpression(string selection, string alias)
            : this(new QualifiedObject(selection), new UnqualifiedObject(alias))
        {
        }

        public SelectExpression(QualifiedObject selection)
            : this(selection, null)
        {
        }

        public SelectExpression(QualifiedObject selection, UnqualifiedObject alias)
        {
            if (selection == null)
                throw new ArgumentNullException("selection", "selection is null.");

            this.selection = selection;
            this.alias = alias;
        }

        private QualifiedObject selection;
        private UnqualifiedObject alias;

        public QualifiedObject Selection
        {
            get
            {
                return selection;
            }
        }

        public UnqualifiedObject Alias
        {
            get
            {
                return alias;
            }
        }

        public SelectExpression As(string alias)
        {
            return this.As(new UnqualifiedObject(alias));
        }

        public SelectExpression As(UnqualifiedObject alias)
        {
            if (this.alias != null)
                throw new InvalidOperationException("Alias already set.");

            var clone = this.Clone();
            clone.alias = alias;
            return clone;
        }

        public static ISelectExpression ParseSelectExpression(string selectExpression)
        {
            var regex = new Regex(@"^((?:(?:\w*|`\w*`)\.)*(?:\w*|`\w*`))(?: as (\w*|`\w*`))?\z", RegexOptions.Compiled);
            var match = regex.Match(selectExpression);
            if (match.Success)
            {
                switch (match.Captures.Count)
                {
                    case 1:
                        return new SelectExpression(match.Captures[0].Value);
                    case 2:
                    default:
                        return new SelectExpression(match.Captures[0].Value, match.Captures[1].Value);
                }
            }

            return new CustomSelectExpression(selectExpression);
        }

        public string BuildSql()
        {
            var builder = new StringBuilder();
            builder.Append(this.Selection.BuildSql());

            if (this.Alias != null)
            {
                builder.Append(" AS ");
                builder.Append(this.Alias.BuildSql());
            }

            return builder.ToString();
        }

        public SelectExpression Clone()
        {
            return new SelectExpression(
                this.selection.Clone(),
                this.alias != null ? this.alias.Clone(): null);
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
