using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Connection;
using Common.Shared;
using Common.Metier;
using Common.Entities;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UserMetierTest
    {
        private User testUser;

        [TestInitialize]
        public void Init()
        {
            Constants.Init();
            SqlAdapter.Init();
            testUser = new User();
            testUser.Id = 1;
            testUser.IdType = 1;
            testUser.Login = "123";
            testUser.Pass = "123";
            testUser.Prenom = "Test";
            testUser.Nom = "NomTest";
            testUser.DateRegister = DateTime.MinValue;
            testUser.UserType.Id = 1;
            testUser.UserType.NameStr = "Free";
        }

        [TestMethod]
        public void GetUserByLoginTest()
        {
            var user = UserMetier.GetUser(testUser.Login);
            Assert.IsTrue(user.Equals(testUser));
        }

        [TestMethod]
        public void GetUserByLoginPasswordTest()
        {
            var user = UserMetier.GetUser(testUser.Login, testUser.Pass);
            Assert.IsTrue(user.Equals(testUser));
        }

        [TestMethod]
        public void GetUserById()
        {
            var user = UserMetier.GetUser(testUser.Id);
            Assert.IsTrue(user.Equals(testUser));
        }

        [TestMethod]
        public void InsertUserTest()
        {
            var sqlParams = new Dictionary<string, object>()
            {
                {"Login", "99" },
                {"Pass", "99" },
                {"IdType", 1 },
                {"Nom", "Unit Test Nom" },
                {"Prenom", "Unit Test Prenom" },
                {"DateRegister",  DateTime.Now },
            };
            var id = UserMetier.InsertUser(sqlParams);
            var newUser = UserMetier.GetUser(id);
            Assert.IsTrue(newUser.Login.Equals("99"));
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            var user = UserMetier.GetUser("99");
            var sqlParams = new Dictionary<string, object>()
            {
                {"IdType", testUser.IdType },
                {"Nom", "Unit Test Nom Update" },
                {"Prenom", "Unit Test Nom Update" },
                {"DateRegister",  DateTime.Now  },
                {"Id", user.Id }
            };
            var id = UserMetier.UpdateUser(sqlParams);
            Assert.IsTrue(id == 1);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var user = UserMetier.GetUser("99");
            var rows = UserMetier.DeleteUser(user.Id);
            Assert.IsTrue(rows > 0);
        }

        [TestMethod]
        public void FailInsertTest()
        {
            var sqlParams = new Dictionary<string, object>()
            {
                {"Login", testUser.Login },
                {"Pass", testUser.Pass },
                {"IdType", testUser.IdType },
                {"Nom", testUser.Nom },
                {"Prenom", testUser.Prenom },
                {"DateRegister",  testUser.DateRegister },
            };
            var id = UserMetier.InsertUser(sqlParams);
            Assert.IsTrue(id <= 0);
        }
    }
}