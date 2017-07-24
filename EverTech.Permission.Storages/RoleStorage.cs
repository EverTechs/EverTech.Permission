using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Orm.Son.Core;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using EverTech.Permission.Molecules;

namespace EverTech.Permission.Storages
{
    public class RoleStorage
    {
        public int Add(Role entity)
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
                return db.Delete<Role>(id);
            }
        }

        public int Edit(Role entity)
        {
            using (var db = new DbCtx())
            {
                return db.Update(entity);
            }
        }

        public Role GetById(int id)
        {
            using (var db = new DbCtx())
            {
                return db.Find<Role>(id);
            }
        }

        public Tuple<List<RoleMolecule>, int> FindPage(int page, int pageSize, string keyWord)
        {
            using (var db = new DbCtx())
            {
                if (keyWord == null) keyWord = "";
                return db.FindPage<Role, RoleMolecule>(t => t.Name.Contains(keyWord) || t.Code.Contains(keyWord), t => t.Id, page, pageSize, true);
            }
        }
    }
}