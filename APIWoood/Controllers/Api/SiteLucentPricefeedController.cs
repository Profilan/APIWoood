using APIWoood.Models;
using APIWoood.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIWoood.Logic.Services;
using APIWoood.Logic.SharedKernel;
using APIWoood.Filters;
using APIWoood.Logic.Services.Interfaces;
using APIWoood.Logic.MessageBrokers.Publishers;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class SiteLucentPricefeedController : WooodApiController
    {
        private readonly SiteLucentPriceFeedRepository pricelistRepository;
        private ILogger logger;

        public SiteLucentPricefeedController() : base()
        {
            pricelistRepository = new SiteLucentPriceFeedRepository();
            logger = new RabbitMQLogger(MessageBrokerPublisherFactory.Create(Logic.SharedKernel.Enums.MessageBrokerType.RabbitMq));
        }

        /**
         * @api {get} /api/sl-pricefeed Request list of SiteLucent prices
         * @apiVersion 1.0.0
         * @apiName GetSiteLucentPriceFeed
         * @apiGroup Pricelists
         * 
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParamExample Request-Example:
         *      /api/sl-pricefeed
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          [
         *              {
         *                  "GTIN": "5011583419320",
         *                  "SoldBy": "Natuurlijk Wonen",
         *                  "Price": 98.00
         *              },
         *              ...
         *          ]
         *      }
         *              
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/sl-pricefeed")]
        [HttpGet]
        public IHttpActionResult GetSiteLucentPriceFeed()
        {
            try
            {
                var items = pricelistRepository.List();

                var pricelists = new List<SiteLucentPriceFeedDto>();
                foreach (var item in items)
                {
                    pricelists.Add(new SiteLucentPriceFeedDto
                    {
                        GTIN = item.GTIN,
                        SoldBy = item.SoldBy,
                        Price = item.Price,
                    });
                }

                logger.Log(ErrorType.INFO, "GetSiteLucentPriceFeed()", RequestContext.Principal.Identity.Name, "Total in query: " + pricelists.Count(), "api/sl-pricefeed", startDate);

                return Ok(pricelists);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetSiteLucentPriceFeed()", RequestContext.Principal.Identity.Name, e.Message, "api/sl-pricefeed");

                return InternalServerError(e);
            }
        }
    }
}
