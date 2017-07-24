using System;
using System.Web.Http;
using EverTech.Permission.Services;
using EverTech.Permission.Molecules;
using EverTech.Permission.Libs;
using System.Collections.Generic;
using EverTech.Permission.Web.Utils;

namespace EverTech.Permission.Web.Controllers
{
    public class UserController : ApiController
    {
        UserService service = new UserService();

        [HttpPost, ApiException]
        public DataResult<string> Add(UserMolecule model)
        {
            model.AddUser = LoginInfo.Loginer.Id;
            return service.Add(model);
        }

        [HttpPost, ApiException]
        public DataResult<string> Del(int id)
        {
            return service.Del(id);
        }

        public DataResult<string> Del(CommonKeyMolecule model)
        {
            return service.Del(model);
        }

        [HttpPost, ApiException]
        public DataResult<string> Edit(UserMolecule model)
        {
            return service.Edit(model);
        }

        [HttpGet, ApiException]
        public DataResult<UserMolecule> GetById(int id)
        {
            return service.GetById(id);
        }

        [HttpGet, ApiException]
        public DataResult<PageResult<UserMolecule>> FindPage(int id = 1, int pageSize = 10, string keyWord = "")
        {
            return service.FindPage(id, pageSize, keyWord);
        }
    }
}