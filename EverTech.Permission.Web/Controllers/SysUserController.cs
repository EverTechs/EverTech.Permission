using System;
using System.Web.Http;
using EverTech.Permission.Services;
using EverTech.Permission.Molecules;
using EverTech.Permission.Libs;
using System.Collections.Generic;
using EverTech.Permission.Web.Utils;
using System.Net.Http;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;

namespace EverTech.Permission.Web.Controllers
{
    public class SysUserController : ApiController
    {
        SysUserService service = new SysUserService();

        [HttpPost, ApiException, Authorize]
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
        public DataResult<PageResult<SysUserMolecule>> FindPage(int id = 1, int pageSize = 10, string keyWord = "")
        {
            return service.FindPage(id, pageSize, keyWord);
        }

        [HttpPost, ApiException]
        public DataResult<SysUserMolecule> CurUser()
        {
            return new DataResult<SysUserMolecule>(LoginInfo.Admin());
        }

        [HttpPost, ApiException]
        public DataResult<SysUserMolecule> Login(SysUserMolecule loginInfo)
        {
            var result = service.Login(loginInfo.Account, loginInfo.Pwd);
            if (result.IsOk)
            {
                var userData = JsonConvert.SerializeObject(result.Data);
                var ticket = new FormsAuthenticationTicket(1, result.Data.Account, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData);
                var encTicket = FormsAuthentication.Encrypt(ticket);
                var ck = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                ck.Domain = FormsAuthentication.CookieDomain;
                HttpContext.Current.Response.Cookies.Add(ck);
                result.Msg = "登录成功";
            }
            return result;
        }

        [HttpPost, ApiException]
        public DataResult<string> Exit()
        {
            FormsAuthentication.SignOut();
            var result = new DataResult<string>("退出成功");
            return result;
        }


    }
}