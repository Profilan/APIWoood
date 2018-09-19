using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class WooodApiController : ApiController
    {
        public string GetLoggedInUserId()
        {
            var principal = RequestContext.Principal.Identity.Name;
       
            return RequestContext.Principal.Identity.GetUserId();
        }
    }
}
