using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EverTech.Permission.Storages.StorageCore;
using Orm.Son.Core;
using EverTech.Permission.Atoms;

namespace EverTech.Permission.Test
{
    [TestClass]
    public class CreateTable
    {
        [TestMethod]
        public void CreateTables()
        {
            using (var db = new DbCtx())
            {
                var resultUser = db.CreateTable<User>();
                var resultRole = db.CreateTable<Role>(); 
                var resultSysUser = db.CreateTable<SysUser>();
            }
        }



    }
}
