using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Metier;
using System.Linq;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UserTypeMetierTest
    {
        [TestMethod]
        public void GetListUserTypeTest()
        {
            var testTypes = new List<int>(4) { 1, 2 };
            var types = UserTypeMetier.GetUserTypes();
            var rest = types.Select(t => t.Id).Except(testTypes);
            Assert.IsTrue(rest.Count() == 0);
        }

        [TestMethod]
        public void GetUserTypeTest()
        {
            int IdFree = 1;
            var type = UserTypeMetier.GetUserType(IdFree);
            Assert.IsTrue(type.Id == IdFree);
        }
    }
}
