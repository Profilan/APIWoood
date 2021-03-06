﻿using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class DebtorOrderController : WooodApiController
    {
        private readonly DebtorOrderRepository debtorOrderRepository;
        private SystemLogger logger;

        public DebtorOrderController() : base()
        {
            debtorOrderRepository = new DebtorOrderRepository();
            logger = new SystemLogger();
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
                var items = debtorOrderRepository.List("DEBITEURNR_ASC", limit, page);

                var orders = new List<DebtorOrder>();
                foreach (var order in items.Results)
                {
                    orders.Add(new DebtorOrder()
                    {
                        ORDERNR = order.ORDERNR,
                        DEBNR = order.DEBNR,
                        FAKDEBNR = order.FAKDEBNR,
                        REFERENTIE = order.REFERENTIE,
                        OMSCHRIJVING = order.OMSCHRIJVING,
                        ORDDAT = order.ORDDAT.ToString("yyyy-MM-dd HH:mm:ss"),
                        AANTAL_BESTELD = order.AANTAL_BESTELD,
                        ITEMCODE = order.ITEMCODE,
                        AFLEVERDATUM = order.AFLEVERDATUM.ToString("yyyy-MM-dd HH:mm:ss"),
                        OMSCHRIJVING_NL = order.OMSCHRIJVING_NL,
                        OMSCHRIJVING_EN = order.OMSCHRIJVING_EN,
                        OMSCHRIJVING_DE = order.OMSCHRIJVING_DE,
                        AANTAL_GELEV = order.AANT_GELEV,
                        STATUS = order.STATUS,
                        DEL_LANDCODE = order.DEL_LANDCODE.Trim(),
                        SELCODE = order.SELCODE,
                        PRIJS_PER_STUK = order.PRIJS_PER_STUK,
                        SUBTOTAAL = order.SUBTOTAAL
                    });
                }

                var collection = new PagedCollection<DebtorOrder>()
                {
                    _embedded = orders,
                    page_size = items.PageSize,
                    page = items.CurrentPage,
                    total_items = items.RowCount,
                    page_count = items.PageCount
                };

                logger.Log(ErrorType.INFO, "GetPagedDebtorOrders()", RequestContext.Principal.Identity.Name, "Total in query: " + items.Results.Count, "api/woood-deb-order-info/list", startDate);

                return Ok(collection);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetPagedDebtorOrders()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-deb-order-info/list");

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
         *                  "AANTAL_GELEV": 1,
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

                logger.Log(ErrorType.INFO, "GetDebtorOrders()", RequestContext.Principal.Identity.Name, "Total in query: " + debtors.Count(), "api/woood-deb-order-info/list", startDate);

                return Ok(debtors);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetDebtorOrders()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-deb-order-info/list");

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
         *                  "AANTAL_GELEV": 1,
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
        public IHttpActionResult GetPagedDebtorOrdersByDebtor(string debiteurnr, int page, int limit = 25)
        {
            try
            {
                var result = debtorOrderRepository.ListByDebtor(debiteurnr, limit, page);


                if (result.Results.Count > 0)
                {
                    var collection = new PagedCollection<APIWoood.Logic.Models.DebtorOrder>()
                    {
                        _embedded = result.Results,
                        page_size = result.PageSize,
                        page = result.CurrentPage,
                        total_items = result.RowCount,
                        page_count = result.PageCount
                    };
                    logger.Log(ErrorType.INFO, "GetPagedDebtorOrdersByDebtor(" + debiteurnr + ")", RequestContext.Principal.Identity.Name, "Total in query: " + result.Results.Count(), "api/woood-deb-order-info/view/debiteurnr", startDate);

                    return Ok(collection);
                }
                else
                {
                    logger.Log(ErrorType.INFO, "GetPagedDebtorOrdersByDebtor(" + debiteurnr + ")", RequestContext.Principal.Identity.Name, "Total in query: " + result.Results.Count(), "api/woood-deb-order-info/view/debiteurnr", startDate);

                    return Ok(new List<string>());
                }

            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetPagedDebtorOrdersByDebtor(" + debiteurnr + ")", RequestContext.Principal.Identity.Name, e.Message, "api/woood-deb-order-info/view/debiteurnr");

                return InternalServerError(e);
            }

        }

        [Route("api/woood-deb-order-info/view/debiteurnr/{debiteurnr}")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetDebtorOrdersByDebtor(string debiteurnr)
        {
            try
            {
                var items = debtorOrderRepository.ListByDebtor(debiteurnr);


                if (items.Count() > 0)
                {
                    var orders = new List<DebtorOrder>();
                    foreach (var order in items)
                    {
                        orders.Add(new DebtorOrder()
                        {
                            ORDERNR = order.ORDERNR,
                            DEBNR = order.DEBNR,
                            FAKDEBNR = order.FAKDEBNR,
                            REFERENTIE = order.REFERENTIE,
                            OMSCHRIJVING = order.OMSCHRIJVING,
                            ORDDAT = order.ORDDAT.ToString("yyyy-MM-dd HH:mm:ss"),
                            AANTAL_BESTELD = order.AANTAL_BESTELD,
                            ITEMCODE = order.ITEMCODE,
                            AFLEVERDATUM = order.AFLEVERDATUM.ToString("yyyy-MM-dd HH:mm:ss"),
                            OMSCHRIJVING_NL = order.OMSCHRIJVING_NL,
                            OMSCHRIJVING_EN = order.OMSCHRIJVING_EN,
                            OMSCHRIJVING_DE = order.OMSCHRIJVING_DE,
                            AANTAL_GELEV = order.AANT_GELEV,
                            STATUS = order.STATUS,
                            DEL_LANDCODE = order.DEL_LANDCODE.Trim(),
                            SELCODE = order.SELCODE,
                            PRIJS_PER_STUK = order.PRIJS_PER_STUK,
                            SUBTOTAAL = order.SUBTOTAAL
                        });
                    }

                    logger.Log(ErrorType.INFO, "GetDebtorOrdersByDebtor(" + debiteurnr + ")", RequestContext.Principal.Identity.Name, "Total in query: " + items.Count(), "api/woood-deb-order-info/view/debiteurnr", startDate);

                    return Ok(orders);
                }
                else
                {
                    logger.Log(ErrorType.INFO, "GetDebtorOrdersByDebtor(" + debiteurnr + ")", RequestContext.Principal.Identity.Name, "Total in query: " + items.Count(), "api/woood-deb-order-info/view/debiteurnr", startDate);

                    return Ok(new List<string>());
                }

            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetDebtorOrdersByDebtor(" + debiteurnr + ")", RequestContext.Principal.Identity.Name, e.Message, "api/woood-deb-order-info/view/debiteurnr");

                return InternalServerError(e);
            }
        }


    }
}
