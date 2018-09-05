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
    public class ProductRangeController : ApiController
    {
        private readonly ProductRangeRepository productRangeRepository;

        public ProductRangeController()
        {
            productRangeRepository = new ProductRangeRepository();
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
        [Authorize]
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

                return Ok(productRanges);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}
