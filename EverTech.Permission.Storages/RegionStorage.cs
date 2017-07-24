using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Orm.Son.Core;
using EverTech.Permission.Atoms;
using EverTech.Permission.Storages.StorageCore;
using EverTech.Permission.Molecules;

namespace EverTech.Permission.Storages
{
    public class RegionStorage
    {
        public int Add(Region entity)
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
                return db.Delete<Region>(id);
            }
        }

        public int Edit(Region entity)
        {
            using (var db = new DbCtx())
            {
                return db.Update(entity);
            }
        }

        public Region GetById(int id)
        {
            using (var db = new DbCtx())
            {
                return db.Find<Region>(id);
            }
        }

        public Tuple<List<RegionMolecule>, int> FindPage(int page, int pageSize, string keyWord)
        {
            using (var db = new DbCtx())
            {
                    if (keyWord == null) keyWord = "";
                    return db.FindPage<Region, RegionMolecule>(t => t.DistrictName.Contains(keyWord)
                                                                                                || t.CityName.Contains(keyWord)
                                                                                                || t.ProvinceName.Contains(keyWord), t => t.ProvinceId, page, pageSize);
            }
        }
    }
}