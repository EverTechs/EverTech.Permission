using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Orm.Son.Core;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using EverTech.Permission.Molecules;
using System.Linq;

namespace EverTech.Permission.Storages
{
    public class RolePermissionStorage
    {
        public bool Add(List<RolePermission> entities)
        {
            using (var db = new DbCtx())
            {
                    return db.Insert(entities);
            }
        }

        public int Del(int id)
        {
            using (var db = new DbCtx())
            {
                return db.Delete<RolePermission>(t => t.RoleId == id);
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

        public List<int> GetByRoleId(int id)
        {
            using (var db = new DbCtx())
            {
                var list = db.FindMany<RolePermission>(t => t.RoleId == id);
                return list.Select(t => t.PermissionId).ToList();
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