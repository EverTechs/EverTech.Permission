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
                Account = "jerry",
                AddTime = DateTime.Now,
                EditTime = DateTime.Now,
                EMail = "jerry.core@foxmail.com",
                Enable = true,
                Gender = true,
                Name = "jerry",
                Password = "jerry",
                Phone = "18961156547",
            };

            using (var db = new DbCtx())
            {
                var ok = db.Insert(user);
            }
        }
    }
}
