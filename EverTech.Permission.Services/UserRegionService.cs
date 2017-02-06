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
    public class UserRegionService
    {
        UserRegionStorage store = new UserRegionStorage();

        public DataResult<string> Add(UserRegionMolecule model)
        {
            var entity = EntityMapper.Mapper<UserRegionMolecule, UserRegion>(model);
            return store.Add(entity) > 0
                ? new DataResult<string>(true,"添加成功")
                : new DataResult<string>(false, "添加失败");
        }

        public DataResult<string> Del(int id)
        {
            return store.Del(id) > 0
                ? new DataResult<string>(true, "删除成功")
                : new DataResult<string>(false, "删除失败");
        }

        public DataResult<string> Edit(UserRegionMolecule model)
        {
            var entity = EntityMapper.Mapper<UserRegionMolecule, UserRegion>(model);
            return store.Edit(entity) > 0
                ? new DataResult<string>(true, "更新成功")
                : new DataResult<string>(false, "更新失败");
        }

        public DataResult<UserRegionMolecule> GetById(int id)
        {
            var reslut = store.GetById(id);
            var entity = EntityMapper.Mapper<UserRegion,UserRegionMolecule>(reslut);
            return new DataResult<UserRegionMolecule>(entity);
        }

        public DataResult<List<UserRegionMolecule>> FindPage(int page)
        {
            var reslut = store.FindPage(page);
            return new DataResult<List<UserRegionMolecule>>(reslut.Item1);
        }
    }
}