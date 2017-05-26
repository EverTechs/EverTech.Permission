using System;
using System.Web.Http;
using EverTech.Permission.Services;
using EverTech.Permission.Molecules;
using EverTech.Permission.Libs;
using System.Collections.Generic;
using EverTech.Permission.Web.Utils;
using System.Net.Http;
using System.Web;

namespace EverTech.Permission.Web.Controllers
{
    public class SysUserController : ApiController
    {
        SysUserService service = new SysUserService();

        [HttpPost, ApiException]
        public DataResult<string> Add(SysUserMolecule model)
        {
            return service.Add(model);
        }

        [HttpPost, ApiException]
        public DataResult<string> Del(int id)
        {
            return service.Del(id);
        }

        [HttpPost, ApiException]
        public DataResult<string> Edit(SysUserMolecule model)
        {
            return service.Edit(model);
        }

        [HttpGet, ApiException]
        public DataResult<SysUserMolecule> GetById(int id)
        {
            return service.GetById(id);
        }

        [HttpGet, ApiException]
        public DataResult<List<SysUserMolecule>> FindPage(int page)
        {
            return service.FindPage(page);
        }

        [HttpPost, ApiException]
        public DataResult<SysUserMolecule> Login(string account, string pwd)
        {
            var result = service.Login(account, pwd);
            if (result.IsOk)
            {
                var ck = new HttpCookie(".evertech", result.Msg) { HttpOnly = true };
                HttpContext.Current.Response.Cookies.Add(ck);
                result.Msg = "µÇÂ¼³É¹¦";
            }
            return result;
        }



    }
}