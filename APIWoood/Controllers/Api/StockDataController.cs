
using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class StockDataController : WooodApiController
    {
        private readonly UserRepository userRepository;
        private readonly StockDataRepository stockDataRepository;
        private SystemLogger logger;

        public StockDataController()
        {
            stockDataRepository = new StockDataRepository();
            userRepository = new UserRepository();
            logger = new SystemLogger();
        }

        /**
         * @api {get} /api/stock-data Request Stock Data
         * @apiVersion 1.0.0
         * @apiName GetStockDataList
         * @apiGroup StockData
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} apikey Api Key provided by De Eekhoorn Woodworkings B.V.
         * @apiParam {String} [page=1] Page to show
         * @apiParam {String} [limit=25] Number of products on a page
         * 
         * @apiParamExample Request-Example:
         *      /api/stock-data?apikey=0123456789abc&page=1&limit=25
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "_links": {
         *              "self": {
         *                  "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=1"
         *              },
         *              "first": {
         *                  "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data"
         *              },
         *              "last": {
         *                  "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=2833"
         *              },
         *              "next": {
         *                  "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=2"
         *              }
         *          },
         *          "_embedded": {
         *              "stock_data": [
         *                  {
         *                      "ITEMCODE": "001-ANT",
         *                      "EAN": "8714713087440",
         *                      "STOCKLEVEL": 0,
         *                      "STATUS": "COLLECTION",
         *                      "ATP": {
         *                          "date": "2019-02-15 00:00:00.000000",
         *                          "timezone_type": 3,
         *                          "timezone": "Europe/Amsterdam"
         *                      },
         *                      "DFF_SHIPMENT": "CARRIER",
         *                      "_links": {
         *                          "self": {
         *                              "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data/001-ANT"
         *                          }
         *                      }
         *                  },
         *                  ...
         *              ]
         *          },
         *          "page_count": 2833,
         *          "page_size": 25,
         *          "total_items": 2833,
         *          "page": 1
         *      }
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * @apiError (Error 4xx) {401} NotAuthorized API key is missing.
         * 
         */
        [Route("api/stock-data")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetStockDataList(string apikey, int page = 1, int limit = 25)
        {
            try
            {
                var result = stockDataRepository.GetStockDataList(limit, page);
                var uri = Request.RequestUri.AbsoluteUri.Split('?')[0];

                var link = new Link();
                link.Self = new LinkHref() { Href = uri + "?apikey=" + apikey + "&page=" + page };
                link.First = new LinkHref() { Href = uri + "?apikey=" + apikey };
                link.Last = new LinkHref() { Href = uri + "?apikey=" + apikey + "&page=" + result.PageCount };
                if (page < result.PageCount)
                {
                    var nextPage = page + 1;
                    link.Next = new LinkHref() { Href = uri + "?apikey=" + apikey + "&page=" + nextPage };
                }
                if (page > 1)
                {
                    var prevPage = page - 1;
                    link.Prev = new LinkHref() { Href = uri + "?apikey=" + apikey + "&page=" + prevPage };
                }

                var collection = new HalCollection<StockData>()
                {
                    Link = link,
                    PageCount = result.PageCount,
                    PageSize = result.PageSize,
                    TotalItems = result.RowCount,
                    CurrentPage = page
                };
                var items = new List<StockData>();
                
                foreach (var item in result.Results)
                {
                    var atp = new StockDataAtp(item.ATP);

                    var stockData = new StockData()
                    {
                        ITEMCODE = item.ITEMCODE,
                        EAN = item.EAN,
                        STOCKLEVEL = item.STOCKLEVEL,
                        STATUS = item.STATUS,
                        ATP = atp,
                        DFF_SHIPMENT = item.DFF_SHIPMENT,
                        Link = new Link()
                        {
                            Self = new LinkHref() { Href = uri + "/" + item.ITEMCODE + "?apikey=" + apikey }
                        }
                    };
                    items.Add(stockData);
                }
                collection.Embedded.Add("stock_data", items);

                return Ok(collection);
            }
            catch
            {

                throw;
            }
        }

        /**
         * @api {get} /api/stock-data Request Stock Data by Debtorcode
         * @apiVersion 1.0.0
         * @apiName GetStockDataListByDebtor
         * @apiGroup StockData
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} apikey Api Key provided by De Eekhoorn Woodworkings B.V.
         * @apiParam {String} debcode Debtor Code
         * @apiParam {String} [page=1] Page to show
         * @apiParam {String} [limit=25] Number of products on a page
         * 
         * @apiParamExample Request-Example:
         *      /api/stock-data?apikey=0123456789abc&page=1&limit=25&debcode=123
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "_links": {
         *              "self": {
         *                  "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=1"
         *              },
         *              "first": {
         *                  "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data"
         *              },
         *              "last": {
         *                  "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=2833"
         *              },
         *              "next": {
         *                  "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=2"
         *              }
         *          },
         *          "_embedded": {
         *              "stock_data": [
         *                  {
         *                      "ITEMCODE": "001-ANT",
         *                      "EAN": "8714713087440",
         *                      "STOCKLEVEL": 0,
         *                      "STATUS": "COLLECTION",
         *                      "ATP": {
         *                          "date": "2019-02-15 00:00:00.000000",
         *                          "timezone_type": 3,
         *                          "timezone": "Europe/Amsterdam"
         *                      },
         *                      "DFF_SHIPMENT": "CARRIER",
         *                      "_links": {
         *                          "self": {
         *                              "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data/001-ANT"
         *                          }
         *                      }
         *                  },
         *                  ...
         *              ]
         *          },
         *          "page_count": 2833,
         *          "page_size": 25,
         *          "total_items": 2833,
         *          "page": 1
         *      }
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * @apiError (Error 4xx) {401} NotAuthorized API key is missing.
         * 
         */
        [Route("api/stock-data")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetStockDataListByDebtor(string debcode, string apikey, int page = 1, int limit = 25)
        {
            try
            {
                var result = stockDataRepository.GetStockDataListByDebtor(debcode, limit, page);
                var uri = Request.RequestUri.AbsoluteUri.Split('?')[0];

                var link = new Link();
                link.Self = new LinkHref() { Href = uri + "?apikey=" + apikey + "&debcode=" + debcode + "&page=" + page };
                link.First = new LinkHref() { Href = uri + "?apikey=" + apikey + "&debcode=" + debcode };
                link.Last = new LinkHref() { Href = uri + "?apikey=" + apikey + "&debcode=" + debcode + "&page=" + result.PageCount };
                if (page < result.PageCount)
                {
                    var nextPage = page + 1;
                    link.Next = new LinkHref() { Href = uri + "?apikey=" + apikey + "&debcode=" + debcode + "&page=" + nextPage };
                }
                if (page > 1)
                {
                    var prevPage = page - 1;
                    link.Prev = new LinkHref() { Href = uri + "?apikey=" + apikey + "&debcode=" + debcode + "&page=" + prevPage };
                }

                var collection = new HalCollection<StockData>()
                {
                    Link = link,
                    PageCount = result.PageCount,
                    PageSize = result.PageSize,
                    TotalItems = result.RowCount,
                    CurrentPage = page
                };
                var items = new List<StockData>();

                foreach (var item in result.Results)
                {
                    var atp = new StockDataAtp(item.ATP);

                    var stockData = new StockData()
                    {
                        ITEMCODE = item.ITEMCODE,
                        EAN = item.EAN,
                        STOCKLEVEL = item.STOCKLEVEL,
                        STATUS = item.STATUS,
                        ATP = atp,
                        DFF_SHIPMENT = item.DFF_SHIPMENT,
                        Link = new Link()
                        {
                            Self = new LinkHref() { Href = uri + "/" + item.ITEMCODE + "?apikey=" + apikey }
                        }
                    };
                    items.Add(stockData);
                }
                collection.Embedded.Add("stock_data", items);

                return Ok(collection);
            }
            catch
            {

                throw;
            }
        }

        /**
         * @api {get} /api/stock-data/{id} Request Stock Data by Itemcode
         * @apiVersion 1.0.0
         * @apiName GetStockDataByItemcode
         * @apiGroup StockData
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} apikey Api Key provided by De Eekhoorn Woodworkings B.V.
         * @apiParam {String} itemcode Item Code
         * 
         * @apiParamExample Request-Example:
         *      /api/stock-data/001-ANT?apikey=0123456789abc
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "ITEMCODE": "001-ANT",
         *          "EAN": "8714713087440",
         *          "STOCKLEVEL": 0,
         *          "STATUS": "COLLECTION",
         *          "ATP": {
         *              "date": "2019-02-15 00:00:00.000000",
         *              "timezone_type": 3,
         *              "timezone": "Europe/Amsterdam"
         *          },
         *          "DFF_SHIPMENT": "CARRIER",
         *          "_links": {
         *              "self": {
         *                  "href": "http://apitest.dutchfurniturefulfilment.local/api/stock-data/001-ANT"
         *              }
         *          }
         *      }
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * @apiError (Error 4xx) {401} NotAuthorized API key is missing.
         * 
         */
        [Route("api/stock-data/{id}")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetStockDataById(string id, string apikey)
        {
            try
            {
                var item = stockDataRepository.GetStockDataById(id);
                var uri = Request.RequestUri.AbsoluteUri.Split('?')[0];

                var atp = new StockDataAtp(item.ATP);

                var stockData = new StockData()
                {
                    ITEMCODE = item.ITEMCODE,
                    EAN = item.EAN,
                    STOCKLEVEL = item.STOCKLEVEL,
                    STATUS = item.STATUS,
                    ATP = atp,
                    DFF_SHIPMENT = item.DFF_SHIPMENT,
                    Link = new Link()
                    {
                        Self = new LinkHref() { Href = uri + "?apikey=" + apikey }
                    }
                };
 
                return Ok(stockData);
            }
            catch
            {

                throw;
            }
        }

    }
}
