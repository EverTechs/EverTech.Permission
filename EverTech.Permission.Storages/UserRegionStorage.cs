using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Orm.Son.Core;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using EverTech.Permission.Molecules;

namespace EverTech.Permission.Storages
{
    public class UserRegionStorage
    {
        public int Add(UserRegion entity)
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
                return db.Delete<UserRegion>(id);
            }
        }

        public int Edit(UserRegion entity)
        {
            using (var db = new DbCtx())
            {
                return db.Update(entity);
            }
        }

        public UserRegion GetById(int id)
        {
            using (var db = new DbCtx())
            {
                return db.Find<UserRegion>(id);
            }
        }

        public Tuple<List<UserRegionMolecule>, int> FindPage(int page)
        {
            using (var db = new DbCtx())
            {
                return db.FindPage<UserRegion, UserRegionMolecule>(t => t.Id > 0, t => t.Id, page, 30, true);
            }
        }
    }
}