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
    public class WebAvailabilityController : WooodApiController
    {
        private readonly WebAvailabilityRepository webAvailabilityRepository;
        private SystemLogger logger;

        public WebAvailabilityController() : base()
        {
            webAvailabilityRepository = new WebAvailabilityRepository();
            logger = new SystemLogger();
        }

        /**
         * @api {get} /api/woood-web-availability/list Request web availability list
         * @apiVersion 1.0.0
         * @apiName GetWebAvailability
         * @apiGroup WebAvailability
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-web-availability/list
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      [
         *          {
         *              "FAKDEBNR": "1097685",
         *              "ITEMCODE": "376090",
         *              "TOELICHTING_NL": null,
         *              "TOELICHTING_EN": null,
         *              "TOELICHTING_DE": null,
         *              "TOELICHTING_FR": null,
         *              "LEVERWEEK": 0,
         *              "LEVERWEEK_JJJJWW": "2018-44",
         *              "OMSCHRIJVING_NL": "LAMSVACHT (ASSORTI) INCL VERPAKKING",
         *              "OMSCHRIJVING_EN": "LAMBSKIN (MIX COLOR)",
         *              "OMSCHRIJVING_DE": "LAMMFELL (MIX COLOR)",
         *              "OMSCHRIJVING_FR": "PEAU D' AGNEAU (COULEURS MULTIPLES)",
         *              "BRAND": "BEPUREHOME",
         *              "EXCLUSIVE": "BE PURE DEALERS ONLY",
         *              "EANCODE": "8714713048151"
         *          },
         *          {
         *              "FAKDEBNR": "1097685",
         *              "ITEMCODE": "800739-67",
         *              "TOELICHTING_NL": null,
         *              "TOELICHTING_EN": null,
         *              "TOELICHTING_DE": null,
         *              "TOELICHTING_FR": null,
         *              "LEVERWEEK": 0,
         *              "LEVERWEEK_JJJJWW": "2018-37",
         *              "OMSCHRIJVING_NL": "SPOOL ROLKUSSEN FLUWEEL GRIJS",
         *              "OMSCHRIJVING_EN": "SPOOL CUSHION VELVET GREY",
         *              "OMSCHRIJVING_DE": "SPOOL KISSEN VELVET GRAU",
         *              "OMSCHRIJVING_FR": "SPOOL COUSSIN VELVET GRIS",
         *              "BRAND": "BEPUREHOME",
         *              "EXCLUSIVE": "BE PURE DEALERS ONLY",
         *              "EANCODE": "8714713070466"
         *          },
         *          ...
         *      ]
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-web-availability/list")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetWebAvailability()
        {
            try
            {
                var items = webAvailabilityRepository.List();

                var webAvailabilities = new List<WebAvailability>();
                foreach (var item in items)
                {
                    webAvailabilities.Add(NewWebAvailability(item));
                }

                logger.Log(ErrorType.INFO, "GetWebAvailability()", RequestContext.Principal.Identity.Name, "Total in query: " + webAvailabilities.Count(), "api/woood-web-availability/list", startDate);

                return Ok(webAvailabilities);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetWebAvailability()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-web-availability/list");

                return InternalServerError(e);
            }
        }

        /**
         * @api {get} /api/woood-web-availability/view/fakdebnr/{fakdebnr} Request web availability list by Debtor
         * @apiVersion 1.0.0
         * @apiName GetWebAvailabilityByDebtor
         * @apiGroup WebAvailability
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} fakdebnr Debtor Code on the Invoice
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-web-availability/view/fakdebnr/1097685
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      [
         *          {
         *              "FAKDEBNR": "1097685",
         *              "ITEMCODE": "376090",
         *              "TOELICHTING_NL": null,
         *              "TOELICHTING_EN": null,
         *              "TOELICHTING_DE": null,
         *              "TOELICHTING_FR": null,
         *              "LEVERWEEK": 0,
         *              "LEVERWEEK_JJJJWW": "2018-44",
         *              "OMSCHRIJVING_NL": "LAMSVACHT (ASSORTI) INCL VERPAKKING",
         *              "OMSCHRIJVING_EN": "LAMBSKIN (MIX COLOR)",
         *              "OMSCHRIJVING_DE": "LAMMFELL (MIX COLOR)",
         *              "OMSCHRIJVING_FR": "PEAU D' AGNEAU (COULEURS MULTIPLES)",
         *              "BRAND": "BEPUREHOME",
         *              "EXCLUSIVE": "BE PURE DEALERS ONLY",
         *              "EANCODE": "8714713048151"
         *          },
         *          {
         *              "FAKDEBNR": "1097685",
         *              "ITEMCODE": "800739-67",
         *              "TOELICHTING_NL": null,
         *              "TOELICHTING_EN": null,
         *              "TOELICHTING_DE": null,
         *              "TOELICHTING_FR": null,
         *              "LEVERWEEK": 0,
         *              "LEVERWEEK_JJJJWW": "2018-37",
         *              "OMSCHRIJVING_NL": "SPOOL ROLKUSSEN FLUWEEL GRIJS",
         *              "OMSCHRIJVING_EN": "SPOOL CUSHION VELVET GREY",
         *              "OMSCHRIJVING_DE": "SPOOL KISSEN VELVET GRAU",
         *              "OMSCHRIJVING_FR": "SPOOL COUSSIN VELVET GRIS",
         *              "BRAND": "BEPUREHOME",
         *              "EXCLUSIVE": "BE PURE DEALERS ONLY",
         *              "EANCODE": "8714713070466"
         *          },
         *          ...
         *      ]
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-web-availability/view/fakdebnr/{fakdebnr}")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetWebAvailabilityByDebtor(string fakdebnr)
        {
            try
            {
                var items = webAvailabilityRepository.ListByDebtor(fakdebnr);

                var webAvailabilities = new List<WebAvailability>();
                foreach (var item in items)
                {
                    webAvailabilities.Add(NewWebAvailability(item));
                }

                logger.Log(ErrorType.INFO, "GetWebAvailabilityByDebtor(" + fakdebnr + ")", RequestContext.Principal.Identity.Name, "Total in query: " + webAvailabilities.Count(), "api/woood-web-availability/view/fakdebnr", startDate);

                return Ok(webAvailabilities);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetWebAvailabilityByDebtor(" + fakdebnr + ")", RequestContext.Principal.Identity.Name, e.Message, "api/woood-web-availability/view/fakdebnr");

                return InternalServerError(e);
            }
        }

        private WebAvailability NewWebAvailability(APIWoood.Logic.Models.WebAvailability item)
        {
            return new WebAvailability()
            {
                FAKDEBNR = item.WebAvailabilityIdentifier.FAKDEBNR,
                ITEMCODE = item.WebAvailabilityIdentifier.ITEMCODE,
                TOELICHTING_NL = item.TOELICHTING_NL != null ? item.TOELICHTING_NL : "",
                TOELICHTING_EN = item.TOELICHTING_EN != null ? item.TOELICHTING_EN : "",
                TOELICHTING_DE = item.TOELICHTING_DE != null ? item.TOELICHTING_DE : "",
                TOELICHTING_FR = item.TOELICHTING_FR != null ? item.TOELICHTING_FR : "",
                LEVERWEEK = item.LEVERWEEK == 0 ? Convert.ToString(item.LEVERWEEK) : null,
                LEVERWEEK_JJJJWW = item.LEVERWEEK_JJJJWW,
                OMSCHRIJVING_NL = item.OMSCHRIJVING_NL != null ? item.OMSCHRIJVING_NL : "",
                OMSCHRIJVING_EN = item.OMSCHRIJVING_EN != null ? item.OMSCHRIJVING_EN : "",
                OMSCHRIJVING_DE = item.OMSCHRIJVING_DE != null ? item.OMSCHRIJVING_DE : "",
                OMSCHRIJVING_FR = item.OMSCHRIJVING_FR != null ? item.OMSCHRIJVING_FR : "",
                BRAND = item.BRAND,
                EXCLUSIVE = item.EXCLUSIVE,
                EANCODE = item.EANCODE,
                SYSCREATED = item.SYSCREATED.ToString("yyyy-MM-dd HH:mm:ss"),
                SYSMODIFIED = item.SYSMODIFIED.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }
    }
}
