using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentMySql.Core
{
    public class QualifiedObject : IQuery
    {
        public QualifiedObject(string objectPath)
            : this(objectPath.Split('.'))
        {
        }

        public QualifiedObject(params string[] objectPath)
        {
            if (objectPath.Length == 0)
                throw new ArgumentException("A qualified object must include at least the object name.");
            if (objectPath.Length == 1 && objectPath[0].Contains('.'))
                objectPath = objectPath[0].Split('.');

            this.objectPath = new List<UnqualifiedObject>(objectPath.Length);
            for (int i = 0; i < objectPath.Length; i++)
            {
                var segment = objectPath[i];
                if (!Utils.Objects.IsValidObject(segment))
                    throw new ArgumentException("objectPath segment not valid.", string.Format("objectPath[{0}]", i));

                this.objectPath.Add(new UnqualifiedObject(segment));
            }
        }

        private List<UnqualifiedObject> objectPath;

        public IList<UnqualifiedObject> ObjectPath
        {
            get
            {
                return objectPath.AsReadOnly();
            }
        }

        public string BuildSql()
        {
            return string.Join(".", this.objectPath.Select(s => s.BuildSql()));
        }

        public QualifiedObject Clone()
        {
            return (QualifiedObject)this.MemberwiseClone();
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
