using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using APIWoood.Filters;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
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
        public IHttpActionResult GetPagedDebtors(int limit, int page = 1)
        {
            try
            {
                var result = debtorRepository.List("DEBITEURNR_ASC", limit, page);

                if (result.Results.Count > 0)
                {
                    var debtors = new List<DebtorDto>();
                    foreach (var debtor in result.Results)
                    {
                        debtors.Add(NewDebtor(debtor));
                    }


                    var collection = new PagedCollection<DebtorDto>()
                    {
                        _embedded = debtors,
                        page_size = result.PageSize,
                        page = result.CurrentPage,
                        total_items = result.RowCount,
                        page_count = result.PageCount
                    };

                    logger.Log(ErrorType.INFO, "GetPagedDebtors()", RequestContext.Principal.Identity.Name, "Total in query: " + result.Results.Count, "api/woood-debtors/list", startDate);

                    return Ok(collection);

                }
                else
                {

                    logger.Log(ErrorType.INFO, "GetPagedDebtors()", RequestContext.Principal.Identity.Name, "Total in query: " + result.Results.Count, "api/woood-debtors/list", startDate);

                    return Ok(new List<string>());

                }
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
        public IHttpActionResult GetDebtors()
        {
            try
            {
                var items = debtorRepository.List();

                var debtors = new List<DebtorDto>();
                foreach (var debtor in items)
                {
                    debtors.Add(NewDebtor(debtor));
                }

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
        public IHttpActionResult GetDebtorById(string id)
        {
            try
            {
                var items = debtorRepository.ListById(id);
                var debtors = new List<DebtorDto>();
                foreach (var debtor in items)
                {
                    debtors.Add(NewDebtor(debtor));
                }

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
        public IHttpActionResult GetDebtorsBySearchstring(string searchstring)
        {
            var debtors = debtorRepository.ListBySearchstring(searchstring);

            return Ok(debtors);
        }

        private DebtorDto NewDebtor(Debtor debtor)
        {
            return new DebtorDto()
            {
                NAAM = debtor.NAAM,
                TYPE = debtor.TYPE,
                DEBITEURNR = debtor.DEBITEURNR,
                FAKTUURDEBITEURNR = debtor.FAKTUURDEBITEURNR,
                CLASSIFICATIE = debtor.CLASSIFICATIE,
                CLASS_OMS = debtor.CLASS_OMS,
                BTWNR = debtor.BTWNR != null ? debtor.BTWNR : "",
                BETALINGSCONDITIE = debtor.BETALINGSCONDITIE,
                BETALINGSCONDITIEOMS = debtor.BETALINGSCONDITIEOMS,
                LEVERINGSWIJZE = debtor.LEVERINGSWIJZE != null ? debtor.LEVERINGSWIJZE.Trim() : "",
                WOOOD_NL = debtor.WOOOD_NL,
                PORTAL = debtor.PORTAL,
                FACTADRES = debtor.FACTADRES ?? "",
                FACTPC = debtor.FACTPC,
                FACTPLAATS = debtor.FACTPLAATS ?? "",
                FACTLANDCODE = debtor.FACTLANDCODE != null ? debtor.FACTLANDCODE.Trim() : "",
                FACTLAND = debtor.FACTLAND,
                BEZADRES = debtor.BEZADRES ?? "",
                BEZPC = debtor.BEZPC,
                BEZPLAATS = debtor.BEZPLAATS ?? "",
                BEZLANDCODE = debtor.BEZLANDCODE != null ? debtor.BEZLANDCODE.Trim() : "",
                BEZLAND = debtor.BEZLAND,
                AFLADRES = debtor.AFLADRES ?? "",
                AFLPC = debtor.AFLPC,
                AFLPLAATS = debtor.AFLPLAATS ?? "",
                AFLLANDCODE = debtor.AFLLANDCODE != null ? debtor.AFLLANDCODE.Trim() : "",
                AFLLAND = debtor.AFLLAND,
                POSTADRES = debtor.POSTADRES ?? "",
                POSTPC = debtor.POSTPC,
                POSTPLAATS = debtor.POSTPLAATS ?? "",
                POSTLANDCODE = debtor.POSTLANDCODE != null ? debtor.POSTLANDCODE.Trim() : "",
                POSTLAND = debtor.POSTLAND,
                CMP_NAME = debtor.CMP_NAME,
                KVK = debtor.KVK ?? "",
                FRANCO_LIMIET = debtor.FRANCO_LIMIET,
                MINIMUM_ORDER_LIMIET = debtor.MINIMUM_ORDER_LIMIET,
                ORDER_TOESLAG = debtor.ORDER_TOESLAG,
                ACCOUNTMANAGER = debtor.ACCOUNTMANAGER,
                DFF_ACCESSCODE = debtor.DFF_ACCESSCODE,
                OVERRIDE_LIMITS = debtor.OVERRIDE_LIMITS,
                DEB_NAME_ALIAS = debtor.DEB_NAME_ALIAS ?? "",
                DEB_WWW_ALIAS = debtor.DEB_WWW_ALIAS ?? "",
                DEALER_ACTIVATION = debtor.DEALER_ACTIVATION,
                DEALER_BRANDS = debtor.DEALER_BRANDS,
                DEALER_TYPE = debtor.DEALER_TYPE ?? "",
                DEALER_WWW_WOOOD = debtor.DEALER_WWW_WOOOD,
                DEALER_WWW_BPH = debtor.DEALER_WWW_BPH
            };
        }
    }
}
