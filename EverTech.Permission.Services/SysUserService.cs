using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EverTech.Permission.Atoms;
using EverTech.Permission.Steps;
using EverTech.Permission.Storages;
using EverTech.Permission.Libs;
using EverTech.Permission.Molecules;
using Orm.Son.Mapper;
using Sweet.Net.Ext;

namespace EverTech.Permission.Services
{
    public class SysUserService
    {
        SysUserStorage store = new SysUserStorage();

        public DataResult<string> Add(SysUserMolecule model)
        {
            var entity = EntityMapper.Mapper<SysUserMolecule, SysUser>(model);
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

        public DataResult<string> Edit(SysUserMolecule model)
        {
            var entity = EntityMapper.Mapper<SysUserMolecule, SysUser>(model);
            return store.Edit(entity) > 0
                ? new DataResult<string>(true, "更新成功")
                : new DataResult<string>(false, "更新失败");
        }

        public DataResult<SysUserMolecule> GetById(int id)
        {
            var reslut = store.GetById(id);
            var entity = EntityMapper.Mapper<SysUser, SysUserMolecule>(reslut);
            return new DataResult<SysUserMolecule>(entity);
        }

        public DataResult<List<SysUserMolecule>> FindPage(int page)
        {
            var reslut = store.FindPage(page);
            return new DataResult<List<SysUserMolecule>>(reslut.Item1);
        }

        public DataResult<SysUserMolecule> Login(string account, string pwd)
        {
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(pwd))
                return new DataResult<SysUserMolecule>(false, "请输入用户名或密码");

            var reslut = store.GetLoginUser(account, pwd.GetMd5());
            if (reslut == null)
                return new DataResult<SysUserMolecule>(false, "用户名或密码不正确");

            var cookieObj = new
            {
                Id = reslut.Id,
                Account = reslut.Account,
                IsSuper = reslut.IsSuper
            };

            

           // var token = JwtExt.EnToken(cookieObj);

            return new DataResult<SysUserMolecule>(reslut, null);
        }

    }
}