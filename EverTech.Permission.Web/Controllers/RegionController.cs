using System;
using System.Web.Http;
using EverTech.Permission.Services;
using EverTech.Permission.Molecules;
using EverTech.Permission.Libs;
using System.Collections.Generic;
using EverTech.Permission.Web.Utils;

namespace EverTech.Permission.Web.Controllers 
{
	public class RegionController : ApiController
    {
        RegionService service = new RegionService();

		[HttpPost,ApiException]
        public DataResult<string> Add(RegionMolecule model)
        {
            return service.Add(model);
        }

		[HttpPost,ApiException]
        public DataResult<string> Del(int id)
        {
            return service.Del(id);
        }
		
		[HttpPost,ApiException]
        public DataResult<string> Edit(RegionMolecule model)
        {
            return service.Edit(model);
        }

		[HttpGet,ApiException]
        public DataResult<RegionMolecule> GetById(int id)
        {
            return service.GetById(id);
        }

		[HttpGet,ApiException]
        public DataResult<PageResult<RegionMolecule>> FindPage(int id = 1, int pageSize = 10, string keyWord = "")
        {
            return service.FindPage(id, pageSize, keyWord);
        }
    }
}