using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Orm.Son.Core;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using EverTech.Permission.Molecules;

namespace EverTech.Permission.Storages
{
    public class SysUserStorage
    {
        public int Add(SysUser entity)
        {
            using (var db = new DbCtx())
            {
                return db.Insert(entity);
            }
        }

        public int Del(int id)
        {
            using (var db = new DbCtx())
            {
                return db.Delete<SysUser>(id);
            }
        }

        public int Edit(SysUser entity)
        {
            using (var db = new DbCtx())
            {
                return db.Update(entity);
            }
        }

        public SysUser GetById(int id)
        {
            using (var db = new DbCtx())
            {
                return db.Find<SysUser>(id);
            }
        }

        public Tuple<List<SysUserMolecule>, int> FindPage(int page, int pageSize, string keyWord)
        {
            using (var db = new DbCtx())
            {
                if (keyWord == null) keyWord = "";
                return db.FindPage<SysUser, SysUserMolecule>(t => t.Account.Contains(keyWord)
                                                                                            || t.PhoneNumber.Contains(keyWord)
                                                                                            || t.Email.Contains(keyWord), t => t.Id, page, pageSize, true);
            }
        }

        public SysUserMolecule GetLoginUser(string account, string pwd)
        {
            using (var db = new DbCtx())
            {
                return db.Top<SysUser,SysUserMolecule>(t => t.Enable == true && t.Account == account && t.Pwd == pwd);
            }
        }

    }
}