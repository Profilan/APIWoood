using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIWoood.Filters;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class PaymentReleaseController : WooodApiController
    {
        private readonly PaymentReleaseRepository paymentReleaseRepository;
        private readonly UserRepository userRepository;
        private readonly OrderRepository orderRepository;
        private SystemLogger logger;

        public PaymentReleaseController() : base()
        {
            paymentReleaseRepository = new PaymentReleaseRepository();
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();
            logger = new SystemLogger();
        }

        /**
         * @api {post} /api/woood-payment-release/create Create Payment Release
         * @apiVersion 1.0.0
         * @apiName CreatePaymentRelease
         * @apiGroup PaymentReleases
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam (Authentication) {String} api-key Unique key for the user
         * @apiParam (Authentication) {String} username Username of the user
         * @apiParam (Authentication) {String} password Password of the user
         * 
         * @apiParam (Order) {String} REFERENTIE Reference
         * @apiParam (Order) {String} DEBITEURNR Debtor Number
         * @apiParam (Order) {Int} PAYMENT_RELEASE Release Payment
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-order/create?apikey=fftt2sQjjaiSXnX2Qnvr3XnahdDB3ZRDLTnRtpJr
         *      
         * @apiExample {json} Example usage:
         * {
         *      "header":
         *      {
         *          "api-key": "Yi7h9j0gWq4kUX2pPyaYkdNkmu",
         *          "username": "pixel",
         *          "password": "wachtwoord"
         *      },
         *      "body":
         *      {
         *              {
         *                  "REFERENTIE": "TEST_ORDER_F6u16dKf_5",
         *                  "DEBITEURNR": "160405",
         *                  "PAYMENT_RELEASE": "1"
         *              }
         *      }
         * }
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "body": {
         *              "message": "The Release Payment was succesfully added"
         *          }
         *      }
         * 
         * @apiError (Error 4xx) {400} Required field is missing.
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * @apiError (Error 4xx) {401} NotAuthorized API key is missing.
         * @apiError (Error 4xx) {409} DEBITEURNR-REFERENTIE UNKNOWN.
         * 
         */
        [Route("api/woood-payment-release/create")]
        [HttpPost]
        public IHttpActionResult CreatePaymentRelease([FromBody]PaymentReleaseData data)
        {
            if (data == null)
            {
                logger.Log(ErrorType.ERR, "CreatePaymentRelease()", RequestContext.Principal.Identity.Name, "Request is wrong format.", "api/woood-payment-release/create");

                return Content(HttpStatusCode.BadRequest, "Request is wrong format.");
            }
            string apiKey;
            try
            {
                apiKey = data.header.apikey;
            }
            catch (System.Exception)
            {
                logger.Log(ErrorType.ERR, "CreatePaymentRelease()", RequestContext.Principal.Identity.Name, "API key is missing.", "api/woood-payment-release/create");

                return Content(HttpStatusCode.Unauthorized, "API key is missing.");
            }

            var user = userRepository.GetByUsername(data.header.username);
            if (apiKey != user.ApiKey)
            {
                logger.Log(ErrorType.ERR, "CreatePaymentRelease()", RequestContext.Principal.Identity.Name, "API key is not correct. Get a right API key from the service provider.", "api/woood-payment-release/create");

                return Content(HttpStatusCode.Unauthorized, "API key is not correct. Get a right API key from the service provider.");
            }

            if (!ModelState.IsValid)
            {
                logger.Log(ErrorType.ERR, "CreatePaymentRelease()", RequestContext.Principal.Identity.Name, ModelState.ToString(), "api/woood-payment-release/create");

                return BadRequest(ModelState);
            }

            try
            {
                var orderIdentifier = new OrderIdentifier(data.body.REFERENTIE, data.body.DEBITEURNR);

                var existingOrders = orderRepository.GetByIdentifier(orderIdentifier);
                if (existingOrders.Count() == 0)
                {
                    logger.Log(ErrorType.ERR, "CreatePaymentRelease()", RequestContext.Principal.Identity.Name, "DEBITEURNR-REFERENTIE UNKNOWN", "api/woood-payment-release/create");

                    return Content(HttpStatusCode.BadRequest, "DEBITEURNR-REFERENTIE UNKNOWN");
                }

                var paymentToPost = new APIWoood.Logic.Models.PaymentRelease()
                {
                    OrderIdentifier = orderIdentifier,
                    PAYMENT_RELEASE = data.body.PAYMENT_RELEASE,
                    PAYMENT_AMOUNT_COD = data.body.PAYMENT_AMOUNT_COD,
                    PAYMENT_TYPE = data.body.PAYMENT_TYPE
                };

                paymentReleaseRepository.Insert(paymentToPost);

                logger.Log(ErrorType.INFO, "CreatePaymentRelease()", RequestContext.Principal.Identity.Name, "The Release Payment was succesfully added", "api/woood-payment-release/create", startDate);

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
                logger.Log(ErrorType.ERR, "CreatePaymentRelease()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-payment-release/create");

                return InternalServerError(e);
            }
        }
    }
}
