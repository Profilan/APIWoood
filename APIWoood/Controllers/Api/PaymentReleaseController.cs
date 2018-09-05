using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class PaymentReleaseController : ApiController
    {
        private readonly PaymentReleaseRepository paymentReleaseRepository;
        private readonly UserRepository userRepository;
        private readonly OrderRepository orderRepository;

        public PaymentReleaseController()
        {
            paymentReleaseRepository = new PaymentReleaseRepository();
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();
        }

        [Route("api/woood-payment-release/create")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post([FromBody]PaymentReleaseData data)
        {
            string apiKey;
            try
            {
                apiKey = data.header.apikey;
            }
            catch (System.Exception)
            {
                return Content(HttpStatusCode.Unauthorized, "API key is missing.");
            }

            var user = userRepository.GetByUsername(data.header.username);
            if (apiKey != user.ApiKey)
            {
                return Content(HttpStatusCode.Unauthorized, "API key is not correct. Get a right API key from the service provider.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderIdentifier = new OrderIdentifier(data.body.REFERENTIE, data.body.DEBITEURNR);

                var existingOrders = orderRepository.GetByIdentifier(orderIdentifier);
                if (existingOrders.Count() == 0)
                {
                    return Content(HttpStatusCode.BadRequest, "DEBITEURNR-REFERENTIE UNKNOWN");
                }

                var paymentToPost = new APIWoood.Logic.Models.PaymentRelease()
                {
                    OrderIdentifier = orderIdentifier,
                    PAYMENT_RELEASE = data.body.PAYMENT_RELEASE,
                };

                paymentReleaseRepository.Insert(paymentToPost);

                return Ok(new
                {
                    body = new
                    {
                        message = "The Release Payment was succesfully added"
                    }
                });
            }
            catch (Exception e )
            {
                return InternalServerError(e);
            }
        }
    }
}
