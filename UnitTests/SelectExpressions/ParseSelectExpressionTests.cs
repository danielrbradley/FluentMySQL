using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentMySql;

namespace UnitTests.SelectExpressions
{
    [TestClass]
    public class ParseSelectExpressionTests
    {
        [TestMethod]
        public void Table()
        {
            var selectExpression = "table";
            var parsedExpression = SelectExpression.ParseSelectExpression(selectExpression);
            Assert.IsInstanceOfType(parsedExpression, typeof(SelectExpression));
            var expression = (SelectExpression)parsedExpression;
            var expected = "`table`";
            var actual = expression.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QualifiedTable()
        {
            var selectExpression = "db.table";
            var parsedExpression = SelectExpression.ParseSelectExpression(selectExpression);
            Assert.IsInstanceOfType(parsedExpression, typeof(SelectExpression));
            var expression = (SelectExpression)parsedExpression;
            var expected = "`db`.`table`";
            var actual = expression.BuildSql();
            Assert.AreEqual(expected, actual);
        }
    }
}
