using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EverTech.Permission.Atoms;
using EverTech.Permission.Steps;
using EverTech.Permission.Storages;
using EverTech.Permission.Libs;
using EverTech.Permission.Molecules;
using Orm.Son.Mapper;

namespace EverTech.Permission.Services
{
    public class RolePermissionService
    {
        RolePermissionStorage store = new RolePermissionStorage();

        public DataResult<string> Add(RolePermissionMolecule model)
        {
            if (model.RoleIds == null || model.RoleIds.Count == 0)
                throw new Exception("角色不能为空");

            var es = new List<RolePermission>();
            foreach (var rid in model.RoleIds)
            {
                store.Del(rid);
                foreach (var pid in model.PermissionIds)
                    es.Add(new RolePermission
                    {
                        AddTime = DateTime.Now,
                        EditTime = DateTime.Now,
                        RoleId = rid,
                        PermissionId = pid,
                        Enable = true
                    });
            }

            return store.Add(es)
                ? new DataResult<string>(true, "添加成功")
                : new DataResult<string>(false, "添加失败");
        }

        public DataResult<string> Del(int id)
        {
            return store.Del(id) > 0
                ? new DataResult<string>(true, "删除成功")
                : new DataResult<string>(false, "删除失败");
        }

        public DataResult<string> Edit(RolePermissionMolecule model)
        {
            var entity = EntityMapper.Mapper<RolePermissionMolecule, RolePermission>(model);
            return store.Edit(entity) > 0
                ? new DataResult<string>(true, "更新成功")
                : new DataResult<string>(false, "更新失败");
        }

        public DataResult<RolePermissionMolecule> GetById(int id)
        {
            var reslut = store.GetById(id);
            var entity = EntityMapper.Mapper<RolePermission, RolePermissionMolecule>(reslut);
            return new DataResult<RolePermissionMolecule>(entity);
        }

        public DataResult<List<int>> GetByRoleId(int id)
        {
            var reslut = store.GetByRoleId(id);
            return new DataResult<List<int>>(reslut);
        }

        public DataResult<List<RolePermissionMolecule>> FindPage(int page)
        {
            var reslut = store.FindPage(page);
            return new DataResult<List<RolePermissionMolecule>>(reslut.Item1);
        }
    }
}