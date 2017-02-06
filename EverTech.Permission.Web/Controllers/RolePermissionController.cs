using System;
using System.Web.Http;
using EverTech.Permission.Services;
using EverTech.Permission.Molecules;
using EverTech.Permission.Libs;
using System.Collections.Generic;
using EverTech.Permission.Web.Utils;

namespace EverTech.Permission.Web.Controllers 
{
	public class RolePermissionController : ApiController
    {
        RolePermissionService service = new RolePermissionService();

		[HttpPost,ApiException]
        public DataResult<string> Add(RolePermissionMolecule model)
        {
            return service.Add(model);
        }

		[HttpPost,ApiException]
        public DataResult<string> Del(int id)
        {
            return service.Del(id);
        }
		
		[HttpPost,ApiException]
        public DataResult<string> Edit(RolePermissionMolecule model)
        {
            return service.Edit(model);
        }

		[HttpGet,ApiException]
        public DataResult<RolePermissionMolecule> GetById(int id)
        {
            return service.GetById(id);
        }

		[HttpGet,ApiException]
        public DataResult<List<RolePermissionMolecule>> FindPage(int page)
        {
            return service.FindPage(page);
        }
    }
}