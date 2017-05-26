using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EverTech.Permission.Web.Controllers
{
    public class DocController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "API IS RUNNING";
        }
    }
}
