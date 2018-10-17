using APIWoood.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    [Authorize]
    public class UrlController : ApiController
    {
        private readonly UrlRepository urlRepository;

        public UrlController()
        {
            urlRepository = new UrlRepository();
        }


        // POST: Url/Delete/5
        [Route("api/Url/Delete/{id}")]
        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                urlRepository.Delete(id);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }

        [Route("api/url/{searchstring}")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetUrlsBySearchstring(string searchstring)
        {
            var urls = urlRepository.ListBySearchstring(searchstring);

            return Ok(urls);
        }
    }
}
