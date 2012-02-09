using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentMySql;

namespace UnitTests.TableReferences
{
    [TestClass]
    public class BuildSqlTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoSegments()
        {
            var tableReference = new FromTable();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidSegments()
        {
            var tableReference = new FromTable("foo*bar");
        }

        [TestMethod]
        public void SingleSegment()
        {
            var tableReference = new FromTable("table");
            var expected = "FROM `table`";
            var actual = tableReference.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleQuotedSegment()
        {
            var tableReference = new FromTable("`table`");
            var expected = "FROM `table`";
            var actual = tableReference.BuildSql();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiSegment()
        {
            var tableReference = new FromTable("database", "table");
            var expected = "FROM `database`.`table`";
            var actual = tableReference.BuildSql();
            Assert.AreEqual(expected, actual);
        }
    }
}
