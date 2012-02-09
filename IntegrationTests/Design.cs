using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentMySql;

namespace IntegrationTests
{
    [TestClass]
    public class Design
    {
        [TestMethod]
        public void SelectFrom()
        {
            var query = Query.Select("id", "title", "create", "modified").From("pages");
            var expected = "SELECT `id`, `title`, `create`, `modified` FROM `pages`;";
            var actual = query.BuildSql();
            Assert.AreEqual(expected, actual);
        }
    }
}
