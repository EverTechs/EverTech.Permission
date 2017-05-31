using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Orm.Son.Core;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using EverTech.Permission.Molecules;

namespace EverTech.Permission.Storages
{
    public class UserStorage
    {
        public int Add(User entity)
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
                return db.Delete<User>(id);
            }
        }

        public int Del(List<int> ids)
        {
            using (var db = new DbCtx())
            {
                return db.Delete<User>(ids);
            }
        }

        public int Edit(User entity)
        {
            using (var db = new DbCtx())
            {
                return db.Update(entity);
            }
        }

        public User GetById(int id)
        {
            using (var db = new DbCtx())
            {
                return db.Find<User>(id);
            }
        }

        public Tuple<List<UserMolecule>, int> FindPage(int page)
        {
            using (var db = new DbCtx())
            {
                return db.FindPage<User, UserMolecule>(t => t.Id > 0, t => t.Id, page, 30, true);
            }
        }
    }
}