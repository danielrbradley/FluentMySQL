using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentMySql;

namespace UnitTests.SelectExpressions
{
    [TestClass]
    public class BuildSqlTests
    {
        [TestMethod]
        public void ColumnOnly()
        {
            var expression = new SelectExpression("column");
            var expected = "`column`";
            var actual = expression.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ColumnAlias()
        {
            var expression = new SelectExpression("column", "alias");
            var expected = "`column` AS `alias`";
            var actual = expression.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TableColumn()
        {
            var expression = new SelectExpression("table.column");
            var expected = "`table`.`column`";
            var actual = expression.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DbTableColumn()
        {
            var expression = new SelectExpression("db.table.column");
            var expected = "`db`.`table`.`column`";
            var actual = expression.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DbTableColumnQuoted()
        {
            var expression = new SelectExpression("`db`.`table`.`column`");
            var expected = "`db`.`table`.`column`";
            var actual = expression.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DbTableColumnMixedQuotes()
        {
            var expression = new SelectExpression("`db`.table.`column`");
            var expected = "`db`.`table`.`column`";
            var actual = expression.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TableColumnAlias()
        {
            var expression = new SelectExpression("table.column", "alias");
            var expected = "`table`.`column` AS `alias`";
            var actual = expression.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DbTableColumnAlias()
        {
            var expression = new SelectExpression("db.table.column", "alias");
            var expected = "`db`.`table`.`column` AS `alias`";
            var actual = expression.BuildSql();
            Assert.AreEqual(expected, actual);
        }
    }
}
