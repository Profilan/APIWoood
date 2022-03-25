using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class CheckController : ApiController
    {
        [Route("api/check")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
