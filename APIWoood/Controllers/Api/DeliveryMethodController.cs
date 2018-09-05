using APIWoood.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class DeliveryMethodController : ApiController
    {
        private readonly DeliveryMethodRepository DeliveryMethodRepository;

        public DeliveryMethodController()
        {
            DeliveryMethodRepository = new DeliveryMethodRepository();
        }

        /**
          * @api {get} /api/woood-leveringswijze/list Request Delivery Method List
          * @apiVersion 1.0.0
          * @apiName GetDeliveryMethods
          * @apiGroup DeliveryMethods
          * 
          *
          * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
          * 
          * @apiParamExample Request-Example:
          *      /api/woood-leveringswijze/list
          *      
          * @apiSuccessExample {json} Success-Response:
          *      HTTP/1.1. 200 OK
          *      [
          *          {
          *              "CODE": "001  ",
          *              "NL_DESC": "Afgehaald door ontvanger",
          *              "EN_DESC": null,
          *              "DE_DESC": null,
          *              "FR_DESC": null
          *          },
          *          {
          *              "CODE": "1    ",
          *              "NL_DESC": "FRANKO HUIS                             ",
          *              "EN_DESC": "FREE HOUSE DELIVERY",
          *              "DE_DESC": "FREI HAUS",
          *              "FR_DESC": null
          *          },
          *          ...
          *      ]
          * 
          * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
          * 
          */
        [Route("api/woood-leveringswijze/list")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetDeliveryMethods()
        {
            try
            {
                var items = DeliveryMethodRepository.List();

                return Ok(items);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /**
          * @api {get} /api/woood-leveringswijze/view/code/{code} Request Delivery Method by Code
          * @apiVersion 1.0.0
          * @apiName GetDeliveryMethodByCode
          * @apiGroup DeliveryMethods
          * 
          *
          * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
          * 
          * @apiParam {String} code Code of the Delivery Method
          * 
          * @apiParamExample Request-Example:
          *      /api/woood-leveringswijze/view/code/001
          *      
          * @apiSuccessExample {json} Success-Response:
          *      HTTP/1.1. 200 OK
          *          {
          *              "CODE": "001  ",
          *              "NL_DESC": "Afgehaald door ontvanger",
          *              "EN_DESC": null,
          *              "DE_DESC": null,
          *              "FR_DESC": null
          *          }
          * 
          * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
          * 
          */
        [Route("api/woood-leveringswijze/view/code/{code}")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetDeliveryMethodByCode(string code)
        {
            try
            {
                var item = DeliveryMethodRepository.GetById(code);

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(item);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
