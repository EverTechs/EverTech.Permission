using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Orm.Son.Core;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using EverTech.Permission.Molecules;

namespace EverTech.Permission.Storages
{
    public class PermissionStorage
    {
        public int Add(Atoms.Permission entity)
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
                return db.Delete<Atoms.Permission>(id);
            }
        }

        public int Edit(Atoms.Permission entity)
        {
            using (var db = new DbCtx())
            {
                return db.Update(entity);
            }
        }

        public Atoms.Permission GetById(int id)
        {
            using (var db = new DbCtx())
            {
                return db.Find<Atoms.Permission>(id);
            }
        }

        public Tuple<List<PermissionMolecule>, int> FindPage(int page)
        {
            using (var db = new DbCtx())
            {
                return db.FindPage<Atoms.Permission, PermissionMolecule>(t => t.Id > 0, t => t.Id, page, 30, true);
            }
        }
    }
}