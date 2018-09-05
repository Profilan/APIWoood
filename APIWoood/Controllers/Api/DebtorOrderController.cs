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
    public class DebtorOrderController : ApiController
    {
        private readonly DebtorOrderRepository debtorOrderRepository;

        public DebtorOrderController()
        {
            debtorOrderRepository = new DebtorOrderRepository();
        }

        /**
         * @api {get} /api/woood-deb-order-info/list?page={page}&limit={limit} Request paged list of debtor orders
         * @apiVersion 1.0.0
         * @apiName GetPagedDebtorOrders
         * @apiGroup DebtorOrders
         * 
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} page Page to show
         * @apiParam {String} [limit=25] Number of products on a page
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-deb-order-info/list?page=1&limit=25
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
        [Route("api/woood-deb-order-info/list")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetPagedDebtorOrders(int page, int limit = 25)
        {
            try
            {
                var result = debtorOrderRepository.List("DEBITEURNR_ASC", limit, page);

                var collection = new PagedCollection<APIWoood.Logic.Models.DebtorOrder>()
                {
                    _embedded = result.Results,
                    page_size = result.PageSize,
                    page = result.CurrentPage,
                    total_items = result.RowCount,
                    page_count = result.PageCount
                };

                return Ok(collection);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /**
         * @api {get} /api/woood-deb-order-info/list Request non-paged list of debtors
         * @apiVersion 1.0.0
         * @apiName GetDebtors
         * @apiGroup DebtorOrders
         * 
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-debtors/list
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      [
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
         *          ]               
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-deb-order-info/list")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetDebtorOrders()
        {
            try
            {
                var debtors = debtorOrderRepository.List();

                return Ok(debtors);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /**
         * @api {get} /api/woood-deb-order-info/view/debiteurnr/{debiteurnr}?page={page}&limit={limit} Request debtor orders by debtor
         * @apiVersion 1.0.0
         * @apiName GetDebtorOrderById
         * @apiGroup DebtorOrders
         * 
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} debiteurnr Debtor number
         * @apiParam {String} page Page to show
         * @apiParam {String} [limit=25] Number of products on a page
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-deb-order-info/view/debiteurnr/000201?page=1&limit=25
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
        [Route("api/woood-deb-order-info/view/debiteurnr/{debiteurnr}")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetDebtorOrdersByDebtor(string debiteurnr, int page, int limit = 25)
        {
            try
            {
                var result = debtorOrderRepository.ListByDebtor(debiteurnr, limit, page);

                var collection = new PagedCollection<APIWoood.Logic.Models.DebtorOrder>()
                {
                    _embedded = result.Results,
                    page_size = result.PageSize,
                    page = result.CurrentPage,
                    total_items = result.RowCount,
                    page_count = result.PageCount
                };

                return Ok(collection);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


    }
}
