using Newtonsoft.Json;
using EverTech.Permission.Libs;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace EverTech.Permission.Web.Utils
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
            else if (actionExecutedContext.Exception is TimeoutException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.RequestTimeout);
            }
            else
            {
                var error = new DataResult<string>(false, actionExecutedContext.Exception.Message);
                actionExecutedContext.Response = ToResponseMessage(error);

            }

            base.OnException(actionExecutedContext);
        }

       
        protected HttpResponseMessage ToResponseMessage(DataResult<string> error)
        {
            var respJson = JsonConvert.SerializeObject(error);
            var bs = Encoding.UTF8.GetBytes(respJson);
            var rm = new HttpResponseMessage();
            {
                MemoryStream ms = new MemoryStream(bs);
                rm.Content = new StreamContent(ms);
                rm.Content.Headers.Add("Content-Type", "application/json; charset=utf-8"); 
            }
            return rm;
        }
    }
}