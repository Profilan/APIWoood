using APIWoood.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class UserController : ApiController
    {
        private readonly UserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository();
        }


        // POST: User/Delete/5
        [Route("api/User/Delete/{id}")]
        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                userRepository.Delete(id);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok();
        }

    }
}
