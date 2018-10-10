using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class WooodApiController : ApiController
    {
        protected DateTime startDate;

        public WooodApiController()
        {
            startDate = DateTime.Now;
        }

        public string GetLoggedInUserId()
        {
            var principal = RequestContext.Principal.Identity.Name;
       
            return RequestContext.Principal.Identity.GetUserId();
        }
    }
}
