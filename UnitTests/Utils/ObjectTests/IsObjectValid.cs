using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentMySql;

namespace UnitTests.Utils.ObjectTests
{
    [TestClass]
    public class IsObjectValid
    {
        [TestMethod]
        public void ValidNonQuoted()
        {
            var segment = "segment";
            Assert.IsTrue(FluentMySql.Utils.Objects.IsValidObject(segment));
        }

        [TestMethod]
        public void ValidQuoted()
        {
            var segment = "`segment`";
            Assert.IsTrue(FluentMySql.Utils.Objects.IsValidObject(segment));
        }

        [TestMethod]
        public void InvalidDot()
        {
            var segment = "seg.ment";
            Assert.IsFalse(FluentMySql.Utils.Objects.IsValidObject(segment));
        }

        [TestMethod]
        public void InvalidNonMatchingQuotes()
        {
            var segment = "`segment";
            Assert.IsFalse(FluentMySql.Utils.Objects.IsValidObject(segment));
        }
    }
}
