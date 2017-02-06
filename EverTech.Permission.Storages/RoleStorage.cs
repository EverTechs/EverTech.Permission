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

        public Tuple<List<RoleMolecule>, int> FindPage(int page)
        {
            using (var db = new DbCtx())
            {
                return db.FindPage<Role, RoleMolecule>(t => t.Id > 0, t => t.Id, page, 30, true);
            }
        }
    }
}