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

namespace APIWoood.Controllers.Api
{
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
        [Authorize]
        public IHttpActionResult GetStructureList(int page = 1, int limit = 25)
        {
            var products = new List<Dictionary<string, object>>();
            try
            {
                var pagedResult = structureRepository.List("MAINPROD_ASC", limit, page);

                foreach (var item in pagedResult.Results)
                {
                    products.Add(GetItem(item.MAINPROD));
                }

                var collection = new PagedCollection<Dictionary<string, object>>()
                {
                    _embedded = products,
                    page_size = pagedResult.PageSize,
                    page = pagedResult.CurrentPage,
                    total_items = pagedResult.RowCount,
                    page_count = pagedResult.PageCount
                };

                logger.Log(ErrorType.INFO, "GetStructureList()", RequestContext.Principal.Identity.Name, "Total in query: " + products.Count(), "api/woood-structureview/list", startDate);

                return Ok(collection);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetStructureList()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-structureview/list");

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
        [Authorize]
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

            var itemDictionary = new Dictionary<string, object>()
                         {
                            { "LVL", 0 },
                            { "SEQ_NO", "000" },
                            { "SEQ_FULL", "000" },
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
                            { "SEQ_NO", seqNo },
                            { "SEQ_FULL", item.SEQ_NO },
                            { "ARTIKELCODE", item.ITEMREQ },
                            { "NL_DESCR", item.NL_ITEMREQ_DESC },
                            { "EN_DESCR", item.EN_ITEMREQ_DESC },
                            { "DE_DESCR", item.DE_ITEMREQ_DESC },
                            { "FR_DESCR", item.FR_ITEMREQ_DESC },
                            { "QTY", item.QTY_PER_MAINPROD },
                            
                        };

                        node.Add(item.SEQ_NO, itemDictionary);
                        GetChildren(ref itemDictionary, mainProd);
                    }
                    else
                    {
                        var prevSeq = item.SEQ_NO.Substring(0, 3 + 4 * (item.LVL - 2));
                        if (prevSeq == (string)node["SEQ_FULL"])
                        {
                            var itemDictionary = new Dictionary<string, object>()
                            {
                                { "LVL", item.LVL },
                                { "SEQ_NO", seqNo },
                                { "SEQ_FULL", item.SEQ_NO },
                                { "ARTIKELCODE", item.ITEMREQ },
                                { "NL_DESCR", item.NL_ITEMREQ_DESC },
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
                return;
            }
        }

        
    }
}
