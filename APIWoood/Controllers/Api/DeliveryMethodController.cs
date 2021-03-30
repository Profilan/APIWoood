using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIWoood.Filters;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class DeliveryMethodController : WooodApiController
    {
        private readonly DeliveryMethodRepository DeliveryMethodRepository;
        private SystemLogger logger;

        public DeliveryMethodController() : base()
        {
            DeliveryMethodRepository = new DeliveryMethodRepository();
            logger = new SystemLogger();
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
        public IHttpActionResult GetDeliveryMethods()
        {
            try
            {
                var items = DeliveryMethodRepository.List();

                logger.Log(ErrorType.INFO, "GetDeliveryMethods()", RequestContext.Principal.Identity.Name, "Total in query: " + items.Count(), "api/woood-leveringswijze/list", startDate);

                return Ok(items);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetDeliveryMethods()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-leveringswijze/list");

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
        public IHttpActionResult GetDeliveryMethodByCode(string code)
        {
            try
            {
                var item = DeliveryMethodRepository.GetById(code);

                if (item == null)
                {
                    logger.Log(ErrorType.WARN, "GetDeliveryMethodByCode(" + code + ")", RequestContext.Principal.Identity.Name, "", "api/woood-leveringswijze/view/code");

                    return NotFound();
                }

                logger.Log(ErrorType.INFO, "GetDeliveryMethodByCode(" + code + ")", RequestContext.Principal.Identity.Name, "", "api/woood-leveringswijze/view/code", startDate);

                return Ok(item);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetDeliveryMethodByCode(" + code + ")", RequestContext.Principal.Identity.Name, e.Message, "api/woood-leveringswijze/view/code");
                return InternalServerError(e);
            }
        }
    }
}
