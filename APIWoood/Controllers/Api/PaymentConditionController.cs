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
    public class PaymentConditionController : WooodApiController
    {
        private readonly PaymentConditionRepository paymentConditionRepository;
        private SystemLogger logger;

        public PaymentConditionController() : base()
        {
            paymentConditionRepository = new PaymentConditionRepository();
            logger = new SystemLogger();
        }

        /**
          * @api {get} /api/woood-betalingsconditie/list Request Payment Condition List
          * @apiVersion 1.0.0
          * @apiName GetPaymentConditions
          * @apiGroup PaymentConditions
          * 
          *
          * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
          * 
          * @apiParamExample Request-Example:
          *      /api/woood-betalingsconditie/list
          *      
          * @apiSuccessExample {json} Success-Response:
          *      HTTP/1.1. 200 OK
          *      [
          *          {
          *              "CODE": "74",
          *              "NL_DESC": "opennl",
          *              "EN_DESC": "en",
          *              "DE_DESC": "de",
          *              "FR_DESC": "fr"
          *          },
          *          ...
          *      ]
          * 
          * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
          * 
          */
        [Route("api/woood-betalingsconditie/list")]
        [HttpGet]
        public IHttpActionResult GetPaymentConditions()
        {
            try
            {
                var items = paymentConditionRepository.List();

                logger.Log(ErrorType.INFO, "GetPaymentConditions()", RequestContext.Principal.Identity.Name, "Total in query: " + items.Count(), "api/woood-betalingsconditie/list", startDate);

                return Ok(items);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetPaymentConditions()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-betalingsconditie/list");

                return InternalServerError(e);
            }
        }

        /**
          * @api {get} /api/woood-betalingsconditie/view/code/{code} Request Payment Condition by Code
          * @apiVersion 1.0.0
          * @apiName GetPaymentConditionByCode
          * @apiGroup PaymentConditions
          * 
          *
          * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
          * 
          * @apiParam {String} code Code of the Payment Condition
          * 
          * @apiParamExample Request-Example:
          *      /api/woood-betalingsconditie/view/code/74
          *      
          * @apiSuccessExample {json} Success-Response:
          *      HTTP/1.1. 200 OK
          *          {
          *              "CODE": "74",
          *              "NL_DESC": "opennl",
          *              "EN_DESC": "en",
          *              "DE_DESC": "de",
          *              "FR_DESC": "fr"
          *          }
          * 
          * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
          * 
          */
        [Route("api/woood-betalingsconditie/view/code/{code}")]
        [HttpGet]
        public IHttpActionResult GetPaymentConditionByCode(string code)
        {
            try
            {
                var item = paymentConditionRepository.GetById(code);

                if (item == null)
                {
                    return NotFound();
                }
                logger.Log(ErrorType.INFO, "GetPaymentConditionByCode(" + code + ")", RequestContext.Principal.Identity.Name, "", "api/woood-betalingsconditie/view/code", startDate);

                return Ok(item);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetPaymentConditionByCode(" + code + ")", RequestContext.Principal.Identity.Name, e.Message, "api/woood-betalingsconditie/view/code");

                return InternalServerError(e);
            }
        }
    }
}
