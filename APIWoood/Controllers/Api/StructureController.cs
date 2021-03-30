using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIWoood.Filters;

namespace APIWoood.Controllers.Api
{
    public class ProductDto
    {
        [JsonProperty("LVL")]
        public string LVL { get; set; }

        [JsonProperty("SEQ_NO")]
        public string SEQ_NO { get; set; }

        [JsonIgnore]
        public string SEQ_FULL { get; set; }

        [JsonProperty("ARTIKELCODE")]
        public string ARTIKELCODE { get; set; }

        [JsonProperty("NL_DESCR")]
        public string NL_DESCR { get; set; }

        [JsonProperty("EN_DESCR")]
        public string EN_DESCR { get; set; }

        [JsonProperty("DE_DESCR")]
        public string DE_DESCR { get; set; }

        [JsonProperty("FR_DESCR")]
        public string FR_DESCR { get; set; }
    }

    public class ProductChildDto
    {
        [JsonProperty("LVL")]
        public int LVL { get; set; }

        [JsonProperty("SEQ_NO")]
        public string SEQ_NO { get; set; }

        [JsonIgnore]
        public string SEQ_FULL { get; set; }

        [JsonProperty("ARTIKELCODE")]
        public string ARTIKELCODE { get; set; }

        [JsonProperty("NL_DESCR")]
        public string NL_DESCR { get; set; }

        [JsonProperty("EN_DESCR")]
        public string EN_DESCR { get; set; }

        [JsonProperty("DE_DESCR")]
        public string DE_DESCR { get; set; }

        [JsonProperty("FR_DESCR")]
        public string FR_DESCR { get; set; }
    }

    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class StructureController : WooodApiController
    {
        private readonly StructureRepository structureRepository;
        private readonly ProductRepository productRepository;
        private SystemLogger logger;

        public StructureController() : base()
        {
            structureRepository = new StructureRepository();
            productRepository = new ProductRepository();
            logger = new SystemLogger();
        }

        /**
         * @api {get} /api/woood-structureview/list[?page={page}&limit={limit} Request structure view list
         * @apiVersion 1.0.0
         * @apiName GetStructureList
         * @apiGroup StructureView
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-structureview/list[?page=20&limit=2
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "_embedded": [
         *              {
         *                  "340447-N": {
         *                      "LVL": 0,
         *                      "SEQ_NO": "000",
         *                      "SEQ_FULL": "000",
         *                      "ARTIKELCODE": "340447-N",
         *                      "NL_DESCR": "MEREL HOEKBANK LINKS NATUREL",
         *                      "EN_DESCR": "MEREL CORNER SOFA LEFT NATUREL",
         *                      "DE_DESCR": "MEREL ECKCOUCH LINKEN NATUREL",
         *                      "FR_DESCR": "MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE",
         *                      "QTY": 1,
         *                      "001": {
         *                          "LVL": 1,
         *                          "SEQ_NO": "001",
         *                          "SEQ_FULL": "001",
         *                          "ARTIKELCODE": "P340447-N 1#3",
         *                          "NL_DESCR": "MEREL HOEKBANK LINKS NATUREL",
         *                          "EN_DESCR": "P1#2 MEREL CORNER SOFA LEFT NATUREL",
         *                          "DE_DESCR": "P1#2 MEREL ECKCOUCH LINKEN NATUREL",
         *                          "FR_DESCR": "P1#2 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE",
         *                          "QTY": 1
         *                      },
         *                      "002": {
         *                          "LVL": 1,
         *                          "SEQ_NO": "002",
         *                          "SEQ_FULL": "002",
         *                          "ARTIKELCODE": "P340447-N 2#3",
         *                          "NL_DESCR": "MEREL HOEKBANK LINKS NATUREL",
         *                          "EN_DESCR": "P2#2 MEREL CORNER SOFA LEFT NATUREL",
         *                          "DE_DESCR": "P2#2 MEREL ECKCOUCH LINKEN NATUREL",
         *                          "FR_DESCR": "P2#2 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE",
         *                          "QTY": 1
         *                      },
         *                      "003": {
         *                          "LVL": 1,
         *                          "SEQ_NO": "003",
         *                          "SEQ_FULL": "003",
         *                          "ARTIKELCODE": "P340447-N 3#3",
         *                          "NL_DESCR": "MEREL HOEKBANK LINKS NATUREL",
         *                          "EN_DESCR": "P3#3 MEREL CORNER SOFA LEFT NATUREL",
         *                          "DE_DESCR": "P3#3 MEREL ECKCOUCH LINKEN NATUREL",
         *                          "FR_DESCR": "3#3 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE",
         *                          "QTY": 1
         *                      }
         *                  }
         *              },
         *              {
         *                  "340448-N": {
         *                      "LVL": 0,
         *                      "SEQ_NO": "000",
         *                      "SEQ_FULL": "000",
         *                      "ARTIKELCODE": "340448-N",
         *                      "NL_DESCR": "MEREL HOEKBANK RECHTS NATUREL",
         *                      "EN_DESCR": "MEREL CORNER SOFA RIGHT NATUREL",
         *                      "DE_DESCR": "MEREL ECKCOUCH RECHTS NATUREL",
         *                      "FR_DESCR": "MEREL CANAPE D ANGLE CÔTELÉ DROITE NATURELLE",
         *                      "QTY": 1,
         *                      "001": {
         *                          "LVL": 1,
         *                          "SEQ_NO": "001",
         *                          "SEQ_FULL": "001",
         *                          "ARTIKELCODE": "P340448-N 1#3",
         *                          "NL_DESCR": "MEREL HOEKBANK RECHTS NATUREL",
         *                          "EN_DESCR": "P1#2 MEREL CORNER SOFA RIGHT NATUREL",
         *                          "DE_DESCR": "P1#2 MEREL ECKCOUCH RECHTS NATUREL",
         *                          "FR_DESCR": "P1#2 MEREL CANAPE D ANGLE CÔTELÉ DROITE NATURELLE",
         *                          "QTY": 1
         *                      },
         *                      "002": {
         *                          "LVL": 1,
         *                          "SEQ_NO": "002",
         *                          "SEQ_FULL": "002",
         *                          "ARTIKELCODE": "P340448-N 2#3",
         *                          "NL_DESCR": "MEREL HOEKBANK RECHTS NATUREL",
         *                          "EN_DESCR": "P2#2 MEREL CORNER SOFA RIGHT NATUREL",
         *                          "DE_DESCR": "P2#2 MEREL ECKCOUCH RECHTS NATUREL",
         *                          "FR_DESCR": "P2#2 MEREL CANAPE D ANGLE CÔTELÉ DROITE NATURELLE",
         *                          "QTY": 1
         *                      },
         *                      "003": {
         *                          "LVL": 1,
         *                          "SEQ_NO": "003",
         *                          "SEQ_FULL": "003",
         *                          "ARTIKELCODE": "P340448-N 3#3",
         *                          "NL_DESCR": "MEREL HOEKBANK RECHTS NATUREL",
         *                          "EN_DESCR": "P3#3 MEREL CORNER SOFA RIGHT NATUREL",
         *                          "DE_DESCR": "P3#3 MEREL ECKCOUCH RECHTS NATUREL",
         *                          "FR_DESCR": "P3#3 MEREL CANAPE D ANGLE CÔTELÉ DROITE NATURELLE",
         *                          "QTY": 1
         *                      }
         *                  }
         *              }
         *          ],
         *          "page_count": 4992,
         *          "page_size": 2,
         *          "total_items": 9983,
         *          "page": 20
         *      }
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-structureview/list")]
        [HttpGet]
        public IHttpActionResult GetStructureList(int page = 1, int limit = 25)
        {
            var products = new List<Dictionary<string, object>>();
            try
            {
                var pagedResult = structureRepository.List("MAINPROD_ASC", limit, page);

                int pageCount = 0;
                foreach (var item in pagedResult.Results)
                {
                    var product = GetItem(item.MAINPROD);
                    if (product != null)
                    {
                        products.Add(GetItem(item.MAINPROD));
                        ++pageCount;
                    }
                }

                var collection = new PagedCollection<Dictionary<string, object>>()
                {
                    _embedded = products,
                    page_size = pagedResult.PageSize,
                    page = pagedResult.CurrentPage,
                    total_items = pagedResult.RowCount,
                    page_count = pageCount
                };

                logger.Log(ErrorType.INFO, "GetStructureList(page = " + page + ", limit = " + limit + ")", RequestContext.Principal.Identity.Name, "Total in query: " + pageCount, "api/woood-structureview/list", startDate);

                return Ok(collection);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetStructureList(page = " + page + ", limit = " + limit + ")", RequestContext.Principal.Identity.Name, e.Message, "api/woood-structureview/list");

                return InternalServerError(e);
            }
        }

        /**
         * @api {get} /api/woood-structureview/view/artikelcode/{artikelcode} Request structure by Article Code
         * @apiVersion 1.0.0
         * @apiName GetStructureByArticle
         * @apiGroup StructureView
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-structureview/view/artikelcode/340447-N
         *      
         * @apiParam {String} artikelcode Article Code
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *              {
         *                  "340447-N": {
         *                      "LVL": 0,
         *                      "SEQ_NO": "000",
         *                      "SEQ_FULL": "000",
         *                      "ARTIKELCODE": "340447-N",
         *                      "NL_DESCR": "MEREL HOEKBANK LINKS NATUREL",
         *                      "EN_DESCR": "MEREL CORNER SOFA LEFT NATUREL",
         *                      "DE_DESCR": "MEREL ECKCOUCH LINKEN NATUREL",
         *                      "FR_DESCR": "MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE",
         *                      "QTY": 1,
         *                      "001": {
         *                          "LVL": 1,
         *                          "SEQ_NO": "001",
         *                          "SEQ_FULL": "001",
         *                          "ARTIKELCODE": "P340447-N 1#3",
         *                          "NL_DESCR": "MEREL HOEKBANK LINKS NATUREL",
         *                          "EN_DESCR": "P1#2 MEREL CORNER SOFA LEFT NATUREL",
         *                          "DE_DESCR": "P1#2 MEREL ECKCOUCH LINKEN NATUREL",
         *                          "FR_DESCR": "P1#2 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE",
         *                          "QTY": 1
         *                      },
         *                      "002": {
         *                          "LVL": 1,
         *                          "SEQ_NO": "002",
         *                          "SEQ_FULL": "002",
         *                          "ARTIKELCODE": "P340447-N 2#3",
         *                          "NL_DESCR": "MEREL HOEKBANK LINKS NATUREL",
         *                          "EN_DESCR": "P2#2 MEREL CORNER SOFA LEFT NATUREL",
         *                          "DE_DESCR": "P2#2 MEREL ECKCOUCH LINKEN NATUREL",
         *                          "FR_DESCR": "P2#2 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE",
         *                          "QTY": 1
         *                      },
         *                      "003": {
         *                          "LVL": 1,
         *                          "SEQ_NO": "003",
         *                          "SEQ_FULL": "003",
         *                          "ARTIKELCODE": "P340447-N 3#3",
         *                          "NL_DESCR": "MEREL HOEKBANK LINKS NATUREL",
         *                          "EN_DESCR": "P3#3 MEREL CORNER SOFA LEFT NATUREL",
         *                          "DE_DESCR": "P3#3 MEREL ECKCOUCH LINKEN NATUREL",
         *                          "FR_DESCR": "3#3 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE",
         *                          "QTY": 1
         *                      }
         *                  }
         *              }         
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-structureview/view/artikelcode/{artikelcode}")]
        [HttpGet]
        public IHttpActionResult GetStructureByArticle(string artikelcode)
        {
             try
             {
                var item = GetItem(artikelcode);

                logger.Log(ErrorType.INFO, "GetStructureByArticle(" + artikelcode + ")", RequestContext.Principal.Identity.Name, "", "api/woood-structureview/view/artikelcode", startDate);

                return Ok(item);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetStructureByArticle(" + artikelcode + ")", RequestContext.Principal.Identity.Name, e.Message, "api/woood-structureview/view/artikelcode");

                return InternalServerError(e);
            }
        }

        private Dictionary<string, object> GetItem(string mainProd)
        {
           
            var product = productRepository.GetById(mainProd);

            if (product != null)
            {
                var itemDictionary = new Dictionary<string, object>()
                         {
                            { "LVL", "0" },
                            { "SEQ_NO", "000" },
                            { "ARTIKELCODE", mainProd },
                            { "NL_DESCR", product.NL },
                            { "EN_DESCR", product.EN },
                            { "DE_DESCR", product.DE },
                            { "FR_DESCR", product.FR },
                            { "QTY", 1 },
                        };

                GetChildren(ref itemDictionary, mainProd);

                var dictionaryToReturn = new Dictionary<string, object>()
                {
                    { mainProd, itemDictionary }
                };

                return dictionaryToReturn;

            }

            return null;
        }

        private void GetChildren(ref Dictionary<string, object> node, string mainProd)
        {
            var items = structureRepository.ListByLevel(Convert.ToInt32(node["LVL"]) + 1, mainProd);

            if (items.Count() > 0)
            {
                foreach (var item in items)
                {
                    var seqArray = item.SEQ_NO.Split('.');
                    var seqNo = seqArray[seqArray.Length - 1];
                    if (seqArray.Length == 1)
                    {
                        var itemDictionary = new Dictionary<string, object>()
                        {
                            { "LVL", item.LVL },
                            { "SEQ_NO", item.SEQ_NO },
                            { "ARTIKELCODE", item.ITEMREQ },
                            { "NL_DESCR", item.ITEMREQ_DESC },
                            { "EN_DESCR", item.EN_ITEMREQ_DESC },
                            { "DE_DESCR", item.DE_ITEMREQ_DESC },
                            { "FR_DESCR", item.FR_ITEMREQ_DESC },
                            { "QTY", item.QTY_PER_MAINPROD },
                            
                        };

                        node.Add(seqNo, itemDictionary);
                        GetChildren(ref itemDictionary, mainProd);
                    }
                    else
                    {
                        var prevSeq = item.SEQ_NO.Substring(0, 3 + 4 * (item.LVL - 2));
                        if (prevSeq == (string)node["SEQ_NO"])
                        {
                            var itemDictionary = new Dictionary<string, object>()
                            {
                                { "LVL", item.LVL },
                                { "SEQ_NO", item.SEQ_NO },
                                { "ARTIKELCODE", item.ITEMREQ },
                                { "NL_DESCR", item.ITEMREQ_DESC },
                                { "EN_DESCR", item.EN_ITEMREQ_DESC },
                                { "DE_DESCR", item.DE_ITEMREQ_DESC },
                                { "FR_DESCR", item.FR_ITEMREQ_DESC },
                                { "QTY", item.QTY_PER_MAINPROD },
                                
                            };

                            node.Add(seqNo, itemDictionary);
                            GetChildren(ref itemDictionary, mainProd);
                        }
                    }
                }
            }
            else
            {
                if (Convert.ToInt32(node["LVL"]) == 0)
                {
                    var product = productRepository.GetById(mainProd);

                    var itemDictionary = new Dictionary<string, object>()
                        {
                            { "LVL", "0" },
                            { "SEQ_NO", "001" },
                            { "ARTIKELCODE", mainProd },
                            { "NL_DESCR", product.NL },
                            { "EN_DESCR", product.EN },
                            { "DE_DESCR", product.DE },
                            { "FR_DESCR", product.FR },
                            { "QTY", 1 },
                        };
                    node.Add("001", itemDictionary);
                }
            }
        }

        
    }
}
