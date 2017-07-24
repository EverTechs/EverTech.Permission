using System;
using System.Web.Http;
using EverTech.Permission.Services;
using EverTech.Permission.Molecules;
using EverTech.Permission.Libs;
using System.Collections.Generic;
using EverTech.Permission.Web.Utils;

namespace EverTech.Permission.Web.Controllers 
{
	public class PermissionController : ApiController
    {
        PermissionService service = new PermissionService();

		[HttpPost,ApiException]
        public DataResult<string> Add(PermissionMolecule model)
        {
            return service.Add(model);
        }

		[HttpPost,ApiException]
        public DataResult<string> Del(int id)
        {
            return service.Del(id);
        }
		
		[HttpPost,ApiException]
        public DataResult<string> Edit(PermissionMolecule model)
        {
            return service.Edit(model);
        }

		[HttpGet,ApiException]
        public DataResult<PermissionMolecule> GetById(int id)
        {
            return service.GetById(id);
        }

		[HttpGet,ApiException]
        public DataResult<PageResult<PermissionMolecule>> FindPage(int id = 1, int pageSize = 10, string keyWord = "",int uid=0)
        {
            return service.FindPage(id, pageSize, keyWord, uid);
        }

        [HttpGet, ApiException]
        public DataResult<TreeDataMolecule> GetTopTreeData(int uid = 0)
        {
            return service.GetTopTreeData(uid);
        }

    }
}