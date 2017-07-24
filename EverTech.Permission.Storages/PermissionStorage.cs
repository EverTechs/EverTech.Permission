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
                var exist = db.Top<Atoms.Permission>(t=>t.Code == entity.Code);
                if (exist != null) throw new Exception("代码已存在");
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
                var exist = db.Top<Atoms.Permission>(t => t.Code == entity.Code && t.Id != entity.Id);
                if (exist != null) throw new Exception("代码已存在");
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

        public Tuple<List<PermissionMolecule>, int> FindPage(int page, int pageSize, string keyWord)
        {
            using (var db = new DbCtx())
            {
                if (keyWord == null) keyWord = "";
                if (keyWord == "PType:40")
                    return db.FindPage<Atoms.Permission, PermissionMolecule>(t => t.Enable == true && t.PType == 40
                                                                                                                        , t => t.EditTime, page, pageSize, true);

                return db.FindPage<Atoms.Permission, PermissionMolecule>(t => t.Name.Contains(keyWord)
                                                                                                              || t.Code.Contains(keyWord)
                                                                                                              || t.ParentCode.Contains(keyWord)
                                                                                                              , t => t.EditTime, page, pageSize, true);
            }
        }

        public TreeDataMolecule GetTopTreeData()
        {
            using (var db = new DbCtx())
            {
                var data = new TreeDataMolecule { Id = 0, Name = "All", Type = 0, Children = new List<TreeDataMolecule>() };
                var result = db.FindMany<Atoms.Permission>(t => t.ParentCode == "" && t.PType != 40 && t.Enable == true);

                foreach (var r in result)
                {
                    var item = new TreeDataMolecule { Id = r.Id, Code = r.Code, ParentCode = r.ParentCode, Name = r.Name, Type = r.PType, Children = new List<TreeDataMolecule>() };
                    data.Children.Add(GetTreeData(item));
                }

                return data;
            }
        }

        public TreeDataMolecule GetTreeData(TreeDataMolecule cur)
        {
            using (var db = new DbCtx())
            {
                var children = db.FindMany<Atoms.Permission>(t => t.ParentCode == cur.Code && t.PType != 40 && t.Enable == true);
                if (children.Count == 0) return cur;

                foreach (var r in children)
                {
                    var item = new TreeDataMolecule { Id = r.Id, Name = r.Name, Code = r.Code, ParentCode = r.ParentCode, Type = r.PType, Children = new List<TreeDataMolecule>() };
                    cur.Children.Add(GetTreeData(item));
                }

                return cur;
            }
        }


    }
}