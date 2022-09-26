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
    public class PricelistController : WooodApiController
    {
        private readonly PricelistRepository pricelistRepository;
        private ILogger logger;

        public PricelistController() : base()
        {
            pricelistRepository = new PricelistRepository();
            logger = new RabbitMQLogger(MessageBrokerPublisherFactory.Create(Logic.SharedKernel.Enums.MessageBrokerType.RabbitMq));
        }

        /**
         * @api {get} /api/woood-pricelist/list?page={page}&limit={limit} Request paged list of debtor orders
         * @apiVersion 1.0.0
         * @apiName GetPricelists
         * @apiGroup Pricelists
         * 
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} page Page to show
         * @apiParam {String} [limit=25] Number of products on a page
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-pricelist/list?page=1&limit=25
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "_embedded": [
         *              {
         *                  "ID": 3241705,
         *                  "ORDERNR": "54294159",
         *                  "DEBNR": "000201",
         *                  "FAKDEBNR": "000201",
         *                  "REFERENTIE": "TEST 54294159",
         *                  "OMSCHRIJVING": "TEST BUITENLAND",
         *                  "ORDDAT": "2016-08-16T00:00:00",
         *                  "AANTAL_BESTELD": 1,
         *                  "ITEMCODE": "XXXXXX",
         *                  "AFLEVERDATUM": "2016-08-16T00:00:00",
         *                  "OMSCHRIJVING_NL": "DUMMY ARTIKEL",
         *                  "OMSCHRIJVING_EN": "DUMMY ARTICLE",
         *                  "OMSCHRIJVING_DE": null,
         *                  "AANT_GELEV": 1,
         *                  "STATUS": 1,
         *                  "DEL_LANDCODE": "DE ",
         *                  "SELCODE": "DE",
         *                  "PRIJS_PER_STUK": 0,
         *                  "SUBTOTAAL": 0
         *              },
         *              ...
         *          ],
         *          "page_count": 3901,
         *          "page_size": 25,
         *          "total_items": 97518,
         *          "page": 1
         *      }
         *              
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-pricelist/list")]
        [HttpGet]
        public IHttpActionResult GetPricelists(int page, int limit = 25)
        {
            try
            {
                var result = pricelistRepository.List("DEBITEURNR_ASC", limit, page);

                var pricelists = new List<Pricelist>();
                foreach (var item in result.Results)
                {
                    pricelists.Add(NewPricelist(item));
                }

                var collection = new PagedCollection<Pricelist>()
                {
                    _embedded = pricelists,
                    page_size = result.PageSize,
                    page = result.CurrentPage,
                    total_items = result.RowCount,
                    page_count = result.PageCount
                };

                logger.Log(ErrorType.INFO, "GetPricelists()", RequestContext.Principal.Identity.Name, "Total in query: " + pricelists.Count(), "api/woood-pricelist/list", startDate);

                return Ok(collection);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetPricelists()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-pricelist/list");

                return InternalServerError(e);
            }
        }

        /**
         * @api {get} /api/woood-pricelist/view/debiteurnr/{debiteurnr}?page={page}&limit={limit} Request pricelists by debtor
         * @apiVersion 1.0.0
         * @apiName GetPricelistsByDebtor
         * @apiGroup Pricelists
         * 
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} debiteurnr Debtor number
         * @apiParam {String} page Page to show
         * @apiParam {String} [limit=25] Number of products on a page
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-pricelist/view/debiteurnr/000201?page=1&limit=25
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "_embedded": [
         *              {
         *                  "ID": 3241705,
         *                  "ORDERNR": "54294159",
         *                  "DEBNR": "000201",
         *                  "FAKDEBNR": "000201",
         *                  "REFERENTIE": "TEST 54294159",
         *                  "OMSCHRIJVING": "TEST BUITENLAND",
         *                  "ORDDAT": "2016-08-16T00:00:00",
         *                  "AANTAL_BESTELD": 1,
         *                  "ITEMCODE": "XXXXXX",
         *                  "AFLEVERDATUM": "2016-08-16T00:00:00",
         *                  "OMSCHRIJVING_NL": "DUMMY ARTIKEL",
         *                  "OMSCHRIJVING_EN": "DUMMY ARTICLE",
         *                  "OMSCHRIJVING_DE": null,
         *                  "AANT_GELEV": 1,
         *                  "STATUS": 1,
         *                  "DEL_LANDCODE": "DE ",
         *                  "SELCODE": "DE",
         *                  "PRIJS_PER_STUK": 0,
         *                  "SUBTOTAAL": 0
         *              },
         *              ...
         *          ],
         *          "page_count": 3901,
         *          "page_size": 25,
         *          "total_items": 97518,
         *          "page": 1
         *      }
         *               
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-pricelist/view/debiteurnr/{debiteurnr}")]
        [HttpGet]
         public IHttpActionResult GetPricelistsByDebtor(string debiteurnr)
        {
            try
            {
                var items = pricelistRepository.ListByDebtor(debiteurnr);

                var pricelists = new List<Pricelist>();
                foreach (var item in items)
                {
                    pricelists.Add(NewPricelist(item));
                }

                logger.Log(ErrorType.INFO, "GetPricelistsByDebtor(" + debiteurnr + ")", RequestContext.Principal.Identity.Name, "Total in query: " + pricelists.Count(), "api/woood-pricelist/view/debiteurnr", startDate);

                return Ok(pricelists);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetPricelistsByDebtor(" + debiteurnr + ")", RequestContext.Principal.Identity.Name, e.ToString(), "api/woood-pricelist/view/debiteurnr");

                return InternalServerError(e);
            }
        }

        private Pricelist NewPricelist(APIWoood.Logic.Models.Pricelist item)
        {
            return new Pricelist()
            {
                ARTIKELCODE = item.PricelistIdentifier.ARTIKELCODE.Trim(),
                FAKTUURDEBITEURNR = item.PricelistIdentifier.FAKTUURDEBITEURNR.Trim(),
                DEBITEURNR = item.PricelistIdentifier.DEBITEURNR.Trim(),
                SALESPRICE = item.SALESPRICE,
                PRIJSLIJST = item.PRIJSLIJST,
                KORTING = item.KORTING,
                AANTAL0 = item.AANTAL0,
                PRIJS0 = item.PRIJS1,
                AANTAL1 = item.AANTAL1,
                PRIJS1 = item.PRIJS1,
                AANTAL2 = item.AANTAL2,
                PRIJS2 = item.PRIJS2,
                AANTAL3 = item.AANTAL3,
                PRIJS3 = item.PRIJS3,
                AANTAL4 = item.AANTAL4,
                PRIJS4 = item.PRIJS4,
                AANTAL5 = item.AANTAL5,
                PRIJS5 = item.PRIJS5,
                AANTAL6 = item.AANTAL6,
                PRIJS6 = item.PRIJS6,
                AANTAL7 = item.AANTAL7,
                PRIJS7 = item.PRIJS7,
                AANTAL8 = item.AANTAL8,
                PRIJS8 = item.PRIJS8,
                AANTAL9 = item.AANTAL9,
                PRIJS9 = item.PRIJS9,
                AANTAL10 = item.AANTAL10,
                PRIJS10 = item.PRIJS10,
                VALCODE = item.VALCODE,
                STANDAARD_SALESPRICE = item.STANDAARD_SALESPRICE,
                KORTINGTYPE = item.KORTINGTYPE,
                PRIJSSOORT = item.PRIJSSOORT,
            };
        }
    }
}
