using System;
using System.Web.Http;
using EverTech.Permission.Services;
using EverTech.Permission.Molecules;
using EverTech.Permission.Libs;
using System.Collections.Generic;
using EverTech.Permission.Web.Utils;

namespace EverTech.Permission.Web.Controllers 
{
	public class UserRegionController : ApiController
    {
        UserRegionService service = new UserRegionService();

		[HttpPost,ApiException]
        public DataResult<string> Add(UserRegionMolecule model)
        {
            return service.Add(model);
        }

		[HttpPost,ApiException]
        public DataResult<string> Del(int id)
        {
            return service.Del(id);
        }
		
		[HttpPost,ApiException]
        public DataResult<string> Edit(UserRegionMolecule model)
        {
            return service.Edit(model);
        }

		[HttpGet,ApiException]
        public DataResult<UserRegionMolecule> GetById(int id)
        {
            return service.GetById(id);
        }

		[HttpGet,ApiException]
        public DataResult<List<UserRegionMolecule>> FindPage(int page)
        {
            return service.FindPage(page);
        }
    }
}