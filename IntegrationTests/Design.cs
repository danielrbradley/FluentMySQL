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
            var query = Query.Select("page_id", "title", "created", "modified").From("page");
            var expected = "SELECT `page_id`, `title`, `created`, `modified` FROM `page`;";
            var actual = query.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SelectFromCustom()
        {
            var query = Query.Select("`page_id` AS `id`, `title`, `created`, `modified`").From("page");
            var expected = "SELECT `page_id` AS `id`, `title`, `created`, `modified` FROM `page`;";
            var actual = query.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SelectFromPredefined()
        {
            var selectColumns = new List<SelectExpression>()
            {
                new SelectExpression("page_id").As("id"),
                new SelectExpression("title"),
                new SelectExpression("created"),
                new SelectExpression("modified")
            };
            var query = Query.Select(selectColumns).From("page");
            var expected = "SELECT `page_id` AS `id`, `title`, `created`, `modified` FROM `page`;";
            var actual = query.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SelectFromWhere()
        {
            var query = Query.Select("page_id", "title", "created", "modified").From("page").Where("title", Op.Equals, new Param("arg1", "A title"));
            var expected = "SELECT `page_id`, `title`, `created`, `modified` FROM `page` WHERE `title` = @arg1;";
            var actual = query.BuildSql();
            Assert.AreEqual(expected, actual);
            var parameters = query.GetParameters();
        }

    }
}
