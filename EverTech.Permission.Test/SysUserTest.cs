using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using Orm.Son.Core;

namespace EverTech.Permission.Test
{
    [TestClass]
    public class SysUserTest
    {

        [TestMethod]
        public void AddUser()
        {
            var user = new SysUser
            {
                Account = "jacky",
                Pwd = "jacky",
                Email = "jacky.core@foxmail.com",
                IsSuper = true,
                Enable = true,
                PhoneNumber = "13000000006",
                AddTime = DateTime.Now
            };

            using (var db = new DbCtx())
            {
                var ok = db.Insert(user);
            }
        }
    }
}
