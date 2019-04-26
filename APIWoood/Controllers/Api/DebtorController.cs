using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class DebtorController : WooodApiController
    {
        private readonly DebtorRepository debtorRepository;
        private SystemLogger logger;
       

        public DebtorController() : base()
        {
            debtorRepository = new DebtorRepository();
            logger = new SystemLogger();
        }

        /**
         * @api {get} /api/woood-debtors/list?page={page}&limit={limit} Request paged list of debtors
         * @apiVersion 1.0.0
         * @apiName GetPagedDebtors
         * @apiGroup Debtors
         * 
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} page Page to show
         * @apiParam {String} [limit=25] Number of products on a page
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-debtors/list?page=1&limit=2
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "_embedded": [
         *              {
         *                  "DEBITEURNR": "000000",
         *                  "NAAM": "Unknown debtor EEKZWD",
         *                  "TYPE": "C",
         *                  "FAKTUURDEBITEURNR": "000000",
         *                  "CLASSIFICATIE": "CA ",
         *                  "CLASS_OMS": "Corporate Account",
         *                  "BTWNR": null,
         *                  "BETALINGSCONDITIE": "09",
         *                  "BETALINGSCONDITIEOMS": "30 DAGEN NETTO",
         *                  "LEVERINGSWIJZE": "ZWA  ",
         *                  "WOOOD_NL": 0,
         *                  "PORTAL": 1,
         *                  "FACTADRES": "Zaadmarkt 25",
         *                  "FACTPC": "1681PD",
         *                  "FACTPLAATS": "Zwaagdijk",
         *                  "FACTLANDCODE": "NL ",
         *                  "FACTLAND": "NEDERLAND",
         *                  "BEZADRES": "Zaadmarkt 25",
         *                  "BEZPC": "1681PD",
         *                  "BEZPLAATS": "Zwaagdijk",
         *                  "BEZLANDCODE": "NL ",
         *                  "BEZLAND": "NEDERLAND",
         *                  "AFLADRES": "Zaadmarkt 25",
         *                  "AFLPC": "1681PD",
         *                  "AFLPLAATS": "Zwaagdijk",
         *                  "AFLLANDCODE": "NL ",
         *                  "AFLLAND": "NEDERLAND",
         *                  "POSTADRES": "Zaadmarkt 25",
         *                  "POSTPC": "1681PD",
         *                  "POSTPLAATS": "Zwaagdijk",
         *                  "POSTLANDCODE": "NL ",
         *                  "POSTLAND": "NEDERLAND",
         *                  "CMP_NAME": "Unknown debtor EEKZWD",
         *                  "KVK": null,
         *                  "FRANCO_LIMIET": 500,
         *                  "MINIMUM_ORDER_LIMIET": 250,
         *                  "ORDER_TOESLAG": 30,
         *                  "ACCOUNTMANAGER": 500491,
         *                  "DFF_ACCESSCODE": "1681",
         *                  "OVERRIDE_LIMITS": 0,
         *                  "DEB_NAME_ALIAS": null,
         *                  "DEB_WWW_ALIAS": null,
         *                  "DEALER_ACTIVATION": 0,
         *                  "DEALER_BRANDS": "WOOOD;BEPUREHOME;VTWONEN",
         *                  "DEALER_TYPE": "DEALER;WEBSHOP"
         *              },
         *              ...
         *          ],
         *          "page_count": 3054,
         *          "page_size": 2,
         *          "total_items": 6108,
         *          "page": 1
         *      }
         *              
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-debtors/list")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetPagedDebtors(int page, int limit = 25)
        {
            try
            {
                var result = debtorRepository.List("DEBITEURNR_ASC", limit, page);

                var collection = new PagedCollection<APIWoood.Logic.Models.Debtor>()
                {
                    _embedded = result.Results,
                    page_size = result.PageSize,
                    page = result.CurrentPage,
                    total_items = result.RowCount,
                    page_count = result.PageCount
                };

                 logger.Log(ErrorType.INFO, "GetPagedDebtors()", RequestContext.Principal.Identity.Name, "Total in query: " + result.Results.Count, "api/woood-debtors/list", startDate);

                return Ok(collection);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetPagedDebtors()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-debtors/list");

                return InternalServerError(e);
            }
         }

        /**
         * @api {get} /api/woood-debtors/list Request non-paged list of debtors
         * @apiVersion 1.0.0
         * @apiName GetDebtors
         * @apiGroup Debtors
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
         *                  "DEBITEURNR": "000000",
         *                  "NAAM": "Unknown debtor EEKZWD",
         *                  "TYPE": "C",
         *                  "FAKTUURDEBITEURNR": "000000",
         *                  "CLASSIFICATIE": "CA ",
         *                  "CLASS_OMS": "Corporate Account",
         *                  "BTWNR": null,
         *                  "BETALINGSCONDITIE": "09",
         *                  "BETALINGSCONDITIEOMS": "30 DAGEN NETTO",
         *                  "LEVERINGSWIJZE": "ZWA  ",
         *                  "WOOOD_NL": 0,
         *                  "PORTAL": 1,
         *                  "FACTADRES": "Zaadmarkt 25",
         *                  "FACTPC": "1681PD",
         *                  "FACTPLAATS": "Zwaagdijk",
         *                  "FACTLANDCODE": "NL ",
         *                  "FACTLAND": "NEDERLAND",
         *                  "BEZADRES": "Zaadmarkt 25",
         *                  "BEZPC": "1681PD",
         *                  "BEZPLAATS": "Zwaagdijk",
         *                  "BEZLANDCODE": "NL ",
         *                  "BEZLAND": "NEDERLAND",
         *                  "AFLADRES": "Zaadmarkt 25",
         *                  "AFLPC": "1681PD",
         *                  "AFLPLAATS": "Zwaagdijk",
         *                  "AFLLANDCODE": "NL ",
         *                  "AFLLAND": "NEDERLAND",
         *                  "POSTADRES": "Zaadmarkt 25",
         *                  "POSTPC": "1681PD",
         *                  "POSTPLAATS": "Zwaagdijk",
         *                  "POSTLANDCODE": "NL ",
         *                  "POSTLAND": "NEDERLAND",
         *                  "CMP_NAME": "Unknown debtor EEKZWD",
         *                  "KVK": null,
         *                  "FRANCO_LIMIET": 500,
         *                  "MINIMUM_ORDER_LIMIET": 250,
         *                  "ORDER_TOESLAG": 30,
         *                  "ACCOUNTMANAGER": 500491,
         *                  "DFF_ACCESSCODE": "1681",
         *                  "OVERRIDE_LIMITS": 0,
         *                  "DEB_NAME_ALIAS": null,
         *                  "DEB_WWW_ALIAS": null,
         *                  "DEALER_ACTIVATION": 0,
         *                  "DEALER_BRANDS": "WOOOD;BEPUREHOME;VTWONEN",
         *                  "DEALER_TYPE": "DEALER;WEBSHOP"
         *              },
         *              ...
         *          ]               
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-debtors/list")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetDebtors()
        {
            try
            {
                var debtors = debtorRepository.List();

                logger.Log(ErrorType.INFO, "GetDebtors()", RequestContext.Principal.Identity.Name, "Total in query: " + debtors.Count(), "api/woood-debtors/list", startDate);

                return Ok(debtors);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetDebtors()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-debtors/list");

                return InternalServerError(e);
            }
        }

        /**
         * @api {get} /api/woood-debtors/view/debiteurnr/{id} Request debtor by id
         * @apiVersion 1.0.0
         * @apiName GetDebtorById
         * @apiGroup Debtors
         * 
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} debiteurnr Debtor number
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-debtors/view/debiteurnr/000000
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *              {
         *                  "DEBITEURNR": "000000",
         *                  "NAAM": "Unknown debtor EEKZWD",
         *                  "TYPE": "C",
         *                  "FAKTUURDEBITEURNR": "000000",
         *                  "CLASSIFICATIE": "CA ",
         *                  "CLASS_OMS": "Corporate Account",
         *                  "BTWNR": null,
         *                  "BETALINGSCONDITIE": "09",
         *                  "BETALINGSCONDITIEOMS": "30 DAGEN NETTO",
         *                  "LEVERINGSWIJZE": "ZWA  ",
         *                  "WOOOD_NL": 0,
         *                  "PORTAL": 1,
         *                  "FACTADRES": "Zaadmarkt 25",
         *                  "FACTPC": "1681PD",
         *                  "FACTPLAATS": "Zwaagdijk",
         *                  "FACTLANDCODE": "NL ",
         *                  "FACTLAND": "NEDERLAND",
         *                  "BEZADRES": "Zaadmarkt 25",
         *                  "BEZPC": "1681PD",
         *                  "BEZPLAATS": "Zwaagdijk",
         *                  "BEZLANDCODE": "NL ",
         *                  "BEZLAND": "NEDERLAND",
         *                  "AFLADRES": "Zaadmarkt 25",
         *                  "AFLPC": "1681PD",
         *                  "AFLPLAATS": "Zwaagdijk",
         *                  "AFLLANDCODE": "NL ",
         *                  "AFLLAND": "NEDERLAND",
         *                  "POSTADRES": "Zaadmarkt 25",
         *                  "POSTPC": "1681PD",
         *                  "POSTPLAATS": "Zwaagdijk",
         *                  "POSTLANDCODE": "NL ",
         *                  "POSTLAND": "NEDERLAND",
         *                  "CMP_NAME": "Unknown debtor EEKZWD",
         *                  "KVK": null,
         *                  "FRANCO_LIMIET": 500,
         *                  "MINIMUM_ORDER_LIMIET": 250,
         *                  "ORDER_TOESLAG": 30,
         *                  "ACCOUNTMANAGER": 500491,
         *                  "DFF_ACCESSCODE": "1681",
         *                  "OVERRIDE_LIMITS": 0,
         *                  "DEB_NAME_ALIAS": null,
         *                  "DEB_WWW_ALIAS": null,
         *                  "DEALER_ACTIVATION": 0,
         *                  "DEALER_BRANDS": "WOOOD;BEPUREHOME;VTWONEN",
         *                  "DEALER_TYPE": "DEALER;WEBSHOP"
         *              }
         *               
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-debtors/view/debiteurnr/{id}")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetDebtorById(string id)
        {
            try
            {
                var debtors = debtorRepository.ListById(id);

                logger.Log(ErrorType.INFO, "GetDebtorById(" + id + ")", RequestContext.Principal.Identity.Name, "Total in query: " + debtors.Count(), "api/woood-debtors/view/debiteurnr", startDate);

                return Ok(debtors);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetDebtorById(" + id + ")", RequestContext.Principal.Identity.Name, e.Message, "api/woood-debtors/view/debiteurnr");

                return InternalServerError(e);

            }
        }

        [Route("api/debtor/{searchstring}")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetDebtorsBySearchstring(string searchstring)
        {
            var debtors = debtorRepository.ListBySearchstring(searchstring);

            return Ok(debtors);
        }
    }
}
