using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EverTech.Permission.Atoms;
using EverTech.Permission.Steps;
using EverTech.Permission.Storages;
using EverTech.Permission.Libs;
using EverTech.Permission.Molecules;
using Orm.Son.Mapper;
using System.Threading;

namespace EverTech.Permission.Services
{
    public class UserService
    {
        UserStorage store = new UserStorage();

        public DataResult<string> Add(UserMolecule model)
        {
            var entity = EntityMapper.Mapper<UserMolecule, User>(model);
            entity.AddTime = DateTime.Now;
            entity.EditTime = DateTime.Now;

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

        public DataResult<string> Del(CommonKeyMolecule model)
        {
            if (model == null || model.Ids==null|| model.Ids.Count == 0)
                return new DataResult<string>(false, "参数不能为空");
            
            return store.Del(model.Ids) > 0
                ? new DataResult<string>(true, "删除成功")
                : new DataResult<string>(false, "删除失败");
        }

        public DataResult<string> Edit(UserMolecule model)
        {
            var entity = EntityMapper.Mapper<UserMolecule, User>(model);
            return store.Edit(entity) > 0
                ? new DataResult<string>(true, "更新成功")
                : new DataResult<string>(false, "更新失败");
        }

        public DataResult<UserMolecule> GetById(int id)
        {
            var reslut = store.GetById(id);
            var entity = EntityMapper.Mapper<User,UserMolecule>(reslut);
            return new DataResult<UserMolecule>(entity);
        }

        public DataResult<List<UserMolecule>> FindPage(int page)
        {
            var reslut = store.FindPage(page);
            return new DataResult<List<UserMolecule>>(reslut.Item1);
        }
    }
}