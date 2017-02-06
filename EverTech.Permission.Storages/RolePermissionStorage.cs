using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Orm.Son.Core;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using EverTech.Permission.Molecules;

namespace EverTech.Permission.Storages
{
    public class RolePermissionStorage
    {
        public int Add(RolePermission entity)
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
                return db.Delete<RolePermission>(id);
            }
        }

        public int Edit(RolePermission entity)
        {
            using (var db = new DbCtx())
            {
                return db.Update(entity);
            }
        }

        public RolePermission GetById(int id)
        {
            using (var db = new DbCtx())
            {
                return db.Find<RolePermission>(id);
            }
        }

        public Tuple<List<RolePermissionMolecule>, int> FindPage(int page)
        {
            using (var db = new DbCtx())
            {
                return db.FindPage<RolePermission, RolePermissionMolecule>(t => t.Id > 0, t => t.Id, page, 30, true);
            }
        }
    }
}