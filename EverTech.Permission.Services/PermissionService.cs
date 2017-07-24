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
    public class PermissionService
    {
        PermissionStorage store = new PermissionStorage();
        RolePermissionStorage rpsStore = new RolePermissionStorage();

        public DataResult<string> Add(PermissionMolecule model)
        {
            var entity = EntityMapper.Mapper<PermissionMolecule, Atoms.Permission>(model);
            entity.EditTime = DateTime.Now;
            entity.AddTime = DateTime.Now;
            return store.Add(entity) > 0
                ? new DataResult<string>(true, "添加成功")
                : new DataResult<string>(false, "添加失败");
        }

        public DataResult<string> Del(int id)
        {
            return store.Del(id) > 0
                ? new DataResult<string>(true, "删除成功")
                : new DataResult<string>(false, "删除失败");
        }

        public DataResult<string> Edit(PermissionMolecule model)
        {
            var entity = EntityMapper.Mapper<PermissionMolecule, Atoms.Permission>(model);
            entity.EditTime = DateTime.Now;
            return store.Edit(entity) > 0
                ? new DataResult<string>(true, "更新成功")
                : new DataResult<string>(false, "更新失败");
        }

        public DataResult<PermissionMolecule> GetById(int id)
        {
            var reslut = store.GetById(id);
            var entity = EntityMapper.Mapper<Atoms.Permission, PermissionMolecule>(reslut);
            return new DataResult<PermissionMolecule>(entity);
        }

        public DataResult<PageResult<PermissionMolecule>> FindPage(int page, int pageSize, string keyWord,int uid)
        {
            var reslut = store.FindPage(page, pageSize, keyWord);
            var resp = new DataResult<PageResult<PermissionMolecule>>
            {
                Data = new PageResult<PermissionMolecule> { Total = reslut.Item2, DataList = reslut.Item1 }
            };

            if (uid > 0) resp.ExtData = rpsStore.GetByRoleId(uid);
            return resp;
        }

        public DataResult<TreeDataMolecule> GetTopTreeData(int uid)
        {
            var result = store.GetTopTreeData();
            if (uid > 0)  result.UserPermissions = rpsStore.GetByRoleId(uid);
            return new DataResult<TreeDataMolecule>(result);
        }

    }
}