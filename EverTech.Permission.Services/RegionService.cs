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
    public class RegionService
    {
        RegionStorage store = new RegionStorage();

        public DataResult<string> Add(RegionMolecule model)
        {
            var entity = EntityMapper.Mapper<RegionMolecule, Region>(model);
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

        public DataResult<string> Edit(RegionMolecule model)
        {
            var entity = EntityMapper.Mapper<RegionMolecule, Region>(model);
            return store.Edit(entity) > 0
                ? new DataResult<string>(true, "更新成功")
                : new DataResult<string>(false, "更新失败");
        }

        public DataResult<RegionMolecule> GetById(int id)
        {
            var reslut = store.GetById(id);
            var entity = EntityMapper.Mapper<Region,RegionMolecule>(reslut);
            return new DataResult<RegionMolecule>(entity);
        }

        public DataResult<List<RegionMolecule>> FindPage(int page)
        {
            var reslut = store.FindPage(page);
            return new DataResult<List<RegionMolecule>>(reslut.Item1);
        }
    }
}