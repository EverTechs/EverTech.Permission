using System;
using System.Web.Http;
using EverTech.Permission.Services;
using EverTech.Permission.Molecules;
using EverTech.Permission.Libs;
using System.Collections.Generic;
using EverTech.Permission.Web.Utils;

namespace EverTech.Permission.Web.Controllers 
{
	public class UserRoleController : ApiController
    {
        UserRoleService service = new UserRoleService();

		[HttpPost,ApiException]
        public DataResult<string> Add(UserRoleMolecule model)
        {
            return service.Add(model);
        }

		[HttpPost,ApiException]
        public DataResult<string> Del(int id)
        {
            return service.Del(id);
        }
		
		[HttpPost,ApiException]
        public DataResult<string> Edit(UserRoleMolecule model)
        {
            return service.Edit(model);
        }

		[HttpGet,ApiException]
        public DataResult<UserRoleMolecule> GetById(int id)
        {
            return service.GetById(id);
        }

		[HttpGet,ApiException]
        public DataResult<List<UserRoleMolecule>> FindPage(int page)
        {
            return service.FindPage(page);
        }
    }
}