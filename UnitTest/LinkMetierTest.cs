using Common.Connection;
using Common.Entities;
using Common.Metier;
using Common.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class LinkMetierTest
    {
        private Link testLink;

        [TestInitialize]
        public void Init()
        {
            Constants.Init();
            SqlAdapter.Init();
            testLink = new Link();
            testLink.DateCreated = DateTime.Now;
            testLink.IdUser = 1;
            testLink.Url = "Unit Test .Net";
        }

        [TestMethod]
        public void GetLinksByUserIdTest()
        {
            var links = LinkMetier.GetLinks(testLink.IdUser);
            var cond = links.TrueForAll(l => l.IdUser == testLink.IdUser);
            Assert.IsTrue(cond);
        }


        [TestMethod]
        public void InsertNewLinkTest()
        {
            var sqlParams = new Dictionary<string, object>()
            {
                {"Url", testLink.Url },
                {"IdUser", testLink.IdUser },
            };

            testLink.Id = LinkMetier.InsertOrUpdateLink(sqlParams);
            Assert.IsTrue(testLink.Id > 0);
        }

        [TestMethod]
        public void GetLinkTest()
        {
            var link = LinkMetier.GetLink(testLink.Url, testLink.IdUser);
            Assert.IsTrue(link.Url.Equals(testLink.Url));
        }

        [TestMethod]
        public void DeleteLinkTest()
        {
            var link = LinkMetier.GetLink(testLink.Url, testLink.IdUser);
            var row = LinkMetier.DeleteLink(link.Id);
            Assert.IsTrue(row > 0);
        }

    }
}
