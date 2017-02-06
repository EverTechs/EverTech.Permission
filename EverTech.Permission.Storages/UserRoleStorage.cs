using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Orm.Son.Core;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using EverTech.Permission.Molecules;

namespace EverTech.Permission.Storages
{
    public class UserRoleStorage
    {
        public int Add(UserRole entity)
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
                return db.Delete<UserRole>(id);
            }
        }

        public int Edit(UserRole entity)
        {
            using (var db = new DbCtx())
            {
                return db.Update(entity);
            }
        }

        public UserRole GetById(int id)
        {
            using (var db = new DbCtx())
            {
                return db.Find<UserRole>(id);
            }
        }

        public Tuple<List<UserRoleMolecule>, int> FindPage(int page)
        {
            using (var db = new DbCtx())
            {
                return db.FindPage<UserRole, UserRoleMolecule>(t => t.Id > 0, t => t.Id, page, 30, true);
            }
        }
    }
}