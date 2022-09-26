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
using APIWoood.Logic.Services.Interfaces;
using APIWoood.Logic.MessageBrokers.Publishers;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class SellingPointController : WooodApiController
    {
        private readonly SellingPointRepository sellingPointRepository;
        private ILogger logger;

        public SellingPointController() : base()
        {
            sellingPointRepository = new SellingPointRepository();
            logger = new RabbitMQLogger(MessageBrokerPublisherFactory.Create(Logic.SharedKernel.Enums.MessageBrokerType.RabbitMq));
        }


        /**
         * @api {get} /api/woood-verkooppunt-view/list Request list of selling points
         * @apiVersion 1.0.0
         * @apiName GetSellingPoints
         * @apiGroup SellingPoints
         * 
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} apikey Unique key for the user
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-verkooppunt-view/list
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      [
         *          {
         *              "ARTIKELCODE": "340358",
         *              "FACTUURDEBITEURNR": "28",
         *              "FACTUURDEBITEURNAAM": "GIGA MEUBEL",
         *              "FACTUURDEBITEUR_NAAM_ALIAS": "Giga Meubel Soest",
         *              "FACTUURDEBITEURWEB": "WWW.GIGAMEUBEL.NL",
         *              "FACTUURDEBITEUR_WEB_ALIAS": "www.gigameubel.nl",
         *              "FACTUURDEBITEURLAND": "NL"
         *          },
         *          {
         *              "ARTIKELCODE": "340358",
         *              "FACTUURDEBITEURNR": "107275",
         *              "FACTUURDEBITEURNAAM": "FONQ.nl B.V.",
         *              "FACTUURDEBITEUR_NAAM_ALIAS": "FonQ.nl",
         *              "FACTUURDEBITEURWEB": "www.fonq.nl",
         *              "FACTUURDEBITEUR_WEB_ALIAS": "www.fonq.nl",
         *              "FACTUURDEBITEURLAND": "NL"
         *          },
         *          ...
         *      ]
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-verkooppunt-view/list")]
        [HttpGet]
        public IHttpActionResult GetSellingPoints()
        {
            try
            {
                var items = sellingPointRepository.List();

                var sellingPoints = new List<SellingPoint>();
                foreach (var item in items)
                {
                    sellingPoints.Add(new SellingPoint()
                    {
                        ARTIKELCODE = item.SellingPointIdentifier.ARTIKELCODE,
                        FACTUURDEBITEURNR = item.SellingPointIdentifier.FACTUURDEBITEURNR,
                        FACTUURDEBITEURNAAM = item.FACTUURDEBITEURNAAM,
                        FACTUURDEBITEUR_NAAM_ALIAS = item.FACTUURDEBITEUR_NAAM_ALIAS,
                        FACTUURDEBITEURWEB = item.FACTUURDEBITEURWEB,
                        FACTUURDEBITEUR_WEB_ALIAS = item.FACTUURDEBITEUR_WEB_ALIAS,
                        FACTUURDEBITEURLAND = item.FACTUURDEBITEURLAND,
                    });
                }

                logger.Log(ErrorType.INFO, "GetSellingPoints()", RequestContext.Principal.Identity.Name, "Total in query: " + items.Count(), "api/woood-verkooppunt-view/list", startDate);

                return Ok(sellingPoints);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetSellingPoints()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-verkooppunt-view/list");

                return InternalServerError(e);
            }
        }

        /**
         * @api {get} /api/woood-verkooppunt-view/view/artikelcode/{artikelcode} Request list of selling points by article
         * @apiVersion 1.0.0
         * @apiName GetSellingPointByArticle
         * @apiGroup SellingPoints
         * 
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} artikelcode Article code
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-verkooppunt-view/view/artikelcode/340358
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      [
         *          {
         *              "ARTIKELCODE": "340358",
         *              "FACTUURDEBITEURNR": "28",
         *              "FACTUURDEBITEURNAAM": "GIGA MEUBEL",
         *              "FACTUURDEBITEUR_NAAM_ALIAS": "Giga Meubel Soest",
         *              "FACTUURDEBITEURWEB": "WWW.GIGAMEUBEL.NL",
         *              "FACTUURDEBITEUR_WEB_ALIAS": "www.gigameubel.nl",
         *              "FACTUURDEBITEURLAND": "NL"
         *          },
         *          {
         *              "ARTIKELCODE": "340358",
         *              "FACTUURDEBITEURNR": "107275",
         *              "FACTUURDEBITEURNAAM": "FONQ.nl B.V.",
         *              "FACTUURDEBITEUR_NAAM_ALIAS": "FonQ.nl",
         *              "FACTUURDEBITEURWEB": "www.fonq.nl",
         *              "FACTUURDEBITEUR_WEB_ALIAS": "www.fonq.nl",
         *              "FACTUURDEBITEURLAND": "NL"
         *          },
         *          ...
         *      ]
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-verkooppunt-view/view/artikelcode/{artikelcode}")]
        [HttpGet]
         public IHttpActionResult GetSellingPointByArticle(string artikelcode)
        {
            try
            {
                var items = sellingPointRepository.ListByArticle(artikelcode);

                var sellingPoints = new List<SellingPoint>();
                foreach (var item in items)
                {
                    sellingPoints.Add(new SellingPoint()
                    {
                        ARTIKELCODE = item.SellingPointIdentifier.ARTIKELCODE,
                        FACTUURDEBITEURNR = item.SellingPointIdentifier.FACTUURDEBITEURNR,
                        FACTUURDEBITEURNAAM = item.FACTUURDEBITEURNAAM,
                        FACTUURDEBITEUR_NAAM_ALIAS = item.FACTUURDEBITEUR_NAAM_ALIAS,
                        FACTUURDEBITEURWEB = item.FACTUURDEBITEURWEB,
                        FACTUURDEBITEUR_WEB_ALIAS = item.FACTUURDEBITEUR_WEB_ALIAS,
                        FACTUURDEBITEURLAND = item.FACTUURDEBITEURLAND,
                    });
                }

                logger.Log(ErrorType.INFO, "GetSellingPointByArticle(" + artikelcode + ")", RequestContext.Principal.Identity.Name, "Total in query: " + items.Count(), "api/woood-verkooppunt-view/view/artikelcode", startDate);

                return Ok(sellingPoints);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetSellingPointByArticle(" + artikelcode + ")", RequestContext.Principal.Identity.Name, e.Message, "api/woood-verkooppunt-view/view/artikelcode");

                return InternalServerError(e);
            }
        }
    }
}
