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
using APIWoood.Logic.MessageBrokers.Publishers;
using APIWoood.Logic.Services.Interfaces;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class ProductRangeController : WooodApiController
    {
        private readonly ProductRangeRepository productRangeRepository;
        private ILogger logger;

        public ProductRangeController() : base()
        {
            productRangeRepository = new ProductRangeRepository();
            logger = new RabbitMQLogger(MessageBrokerPublisherFactory.Create(Logic.SharedKernel.Enums.MessageBrokerType.RabbitMq));
        }

        /**
         * @api {get} /api/woood-assortimenten-view/list/id/{ass} Request list of product ranges by range
         * @apiVersion 1.0.0
         * @apiName GetProductRangeByRange
         * @apiGroup ProductRanges
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} ass Range (Default = 9)
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-assortimenten-view/list/id/9
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      [
         *          {
         *              "ASS": 9,
         *              "CODE": "10",
         *              "OMSCHRIJVING": "LEENBAKKER [NL-BE-LU]"
         *          },
         *          {
         *              "ASS": 9,
         *              "CODE": "10B",
         *              "OMSCHRIJVING": "LEENBAKKER [NL]"
         *          },
         *          {
         *              "ASS": 9,
         *              "CODE": "11",
         *              "OMSCHRIJVING": "KARWEI [NL]"
         *          },
         *          ...
         *      ]
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-assortimenten-view/list/id/{ass}")]
        [HttpGet]
        public IHttpActionResult GetProductRangeByRange(int ass = 9)
        {
            try
            {
                var items = productRangeRepository.ListByRange(ass);

                var productRanges = new List<ProductRange>();
                foreach (var item in items)
                {
                    productRanges.Add(new ProductRange()
                    {
                        ASS = item.ProductRangeIdentifier.ASS,
                        CODE = item.ProductRangeIdentifier.CODE,
                        OMSCHRIJVING = item.OMSCHRIJVING,
                    });
                }

                logger.Log(ErrorType.INFO, "GetProductRangeByRange(" + ass + ")", RequestContext.Principal.Identity.Name, "Total in query: " + productRanges.Count, "api/woood-assortimenten-view/list/id", startDate);

                return Ok(productRanges);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetProductRangeByRange(" + ass + ")", RequestContext.Principal.Identity.Name, e.Message, "api/woood-assortimenten-view/list/id");

                return InternalServerError(e);
            }
        }
        [Route("api/woood-assortimenten-view/list")]
        [HttpGet]
        public IHttpActionResult GetProductRanges()
        {
            try
            {
                var items = productRangeRepository.List().Where(x => x.ProductRangeIdentifier.ASS == 9);

                var productRanges = new List<ProductRange>();
                foreach (var item in items)
                {
                    productRanges.Add(new ProductRange()
                    {
                        ASS = item.ProductRangeIdentifier.ASS,
                        CODE = item.ProductRangeIdentifier.CODE,
                        OMSCHRIJVING = item.OMSCHRIJVING,
                    });
                }

                logger.Log(ErrorType.INFO, "GetProductRanges()", RequestContext.Principal.Identity.Name, "Total in query: " + productRanges.Count, "api/woood-assortimenten-view/list", startDate);

                return Ok(productRanges);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetProductRanges()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-assortimenten-view/list");

                return InternalServerError(e);
            }
        }

    }
}
