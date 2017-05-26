using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using Orm.Son.Core;

namespace EverTech.Permission.Test
{
    [TestClass]
    public class UserTest
    {

        [TestMethod]
        public void AddUser()
        {
            var user = new User
            {
                Account = "jacky",
                AddTime = DateTime.Now,
                EditTime = DateTime.Now,
                EMail = "jacky.core@foxmail.com",
                Enable = true,
                Gender = true,
                Name = "jacky",
                Password = "jacky",
                Phone = "13000000006",
            };

            using (var db = new DbCtx())
            {
                var ok = db.Insert(user);
            }
        }
    }
}
