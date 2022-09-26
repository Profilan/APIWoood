using APIWoood.Filters;
using APIWoood.Logic.MessageBrokers.Publishers;
using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Logic.Services.Interfaces;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using Newtonsoft.Json;
using System.Net;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class ZwaluwSSCCController : WooodApiController
    {
        private readonly ZwaluwSSCCRepository _SSCCRepository = new ZwaluwSSCCRepository();
        private readonly UserRepository userRepository = new UserRepository();
        private ILogger logger = new RabbitMQLogger(MessageBrokerPublisherFactory.Create(Logic.SharedKernel.Enums.MessageBrokerType.RabbitMq));

        /**
         * @api {post} /api/sscc Create SSCC
         * @apiVersion 1.0.0
         * @apiName CreateSSCC
         * @apiGroup Distribution
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam (Authentication) {String} username Username of the user
         * @apiParam (Authentication) {String} password Password of the user
         * 
         * @apiParam (SSCC) {String} ediReference ediReference
         * @apiParam (SSCC) {String} [shipmentNumber] shipmentNumber
         * @apiParam (SSCC) {DateTime} [dateTime] dateTime
         * @apiParam (SSCC) {String} [referenceNumber] 
         * 
         * @apiParam (SSCCOrder) {DateTime} [loadingDate] loadingDate
         * @apiParam (SSCCOrder) {DateTime} [unloadingDate] unloadingDate
         * @apiParam (SSCCOrder) {String} [primaryReference] primaryReference
         * @apiParam (SSCCOrder) {Int} statusCode statusCode
         * @apiParam (SSCCOrder) {String} [orderNumber] orderNumber
         * 
         * @apiParam (SSCCOrderline) {String} orderlineId orderlineId
         * @apiParam (SSCCOrderline) {String} [itemCode] unloadingDate
         * @apiParam (SSCCOrderline) {Decimal} [quantity] quantity
         * 
         * @apiParam (SSCCShipppingDetails) {String} skuCode skuCode
         * @apiParam (SSCCShipppingDetails) {String} [lotCode] lotCode
         * @apiParam (SSCCShipppingDetails) {Decimal} quantity Pallet Quantity
         * 
         * @apiParamExample Request-Example:
         *      /api/sscc
         *      
         * @apiExample {json} Example usage:
         * {
         *     "ediReference": "04-06-2022.637848367651324313",
         *     "shipmentNumber": "21052079",
         *     "dateTime": "2022-04-06T13:23:56+02:00",
         *     "referenceNumber": "Wo000148691",
         *     "order": [
         *         {
         *             "loadingDate": "2022-04-06",
         *             "unloadingDate": "2022-04-06",
         *             "primaryReference": "365124",
         *             "statusCode": 299,
         *             "orderNumber": "78998 - Export",
         *             "orderLine": [
         *                 {
         *                     "orderlineId": 570102,
         *                     "itemCode": "340366-A",
         *                     "quantity": 2.0,
         *                     "shippingDetails": [
         *                         {
         *                             "skuCode": "000000010031241880",
         *                             "lotCode": "41333465_7123113",
         *                             "quantity": 1.0
         *                         },
         *                         {
         *                             "skuCode": "000000010031241881",
         *                             "lotCode": "41333465_7123113",
         *                             "quantity": 1.0
         *                         }
         *                     ]
         *                 }
         *             ]
         *         }
         *   ]
         * }
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         * {
         *     "ediReference": "04-06-2022.637848367651324313",
         *     "shipmentNumber": "21052079",
         *     "dateTime": "2022-04-06T13:23:56+02:00",
         *     "referenceNumber": "Wo000148691",
         *     "order": [
         *         {
         *             "loadingDate": "2022-04-06",
         *             "unloadingDate": "2022-04-06",
         *             "primaryReference": "365124",
         *             "statusCode": 299,
         *             "orderNumber": "78998 - Export",
         *             "orderLine": [
         *                 {
         *                     "orderlineId": 570102,
         *                     "itemCode": "340366-A",
         *                     "quantity": 2.0,
         *                     "shippingDetails": [
         *                         {
         *                             "skuCode": "000000010031241880",
         *                             "lotCode": "41333465_7123113",
         *                             "quantity": 1.0
         *                         },
         *                         {
         *                             "skuCode": "000000010031241881",
         *                             "lotCode": "41333465_7123113",
         *                             "quantity": 1.0
         *                         }
         *                     ]
         *                 }
         *             ]
         *         }
         *   ]
         * }
         * 
         * @apiError (Error 4xx) {400} Required field is missing.
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/sscc")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ZwaluwSSCCDto data)
        {
            if (data == null)
            {
                logger.Log(ErrorType.ERR, "CreateOrder()", RequestContext.Principal.Identity.Name, "Request is wrong format.", "api/sscc/zwaluw/create");

                return Content(HttpStatusCode.BadRequest, "Request is wrong format.");
            }
            var jsonData = JsonConvert.SerializeObject(data);

            if (!ModelState.IsValid)
            {
                logger.Log(ErrorType.ERR, "CreateOrder()", RequestContext.Principal.Identity.Name, ModelState.ToString(), "api/sscc/zwaluw/create");

                return BadRequest(ModelState);
            }

            try
            {
                foreach (var order in data.Orders)
                {
                    foreach (var line in order.Lines)
                    {
                        foreach (var detail in line.ShippingDetails)
                        {
                            var item = new ZwaluwSSCC
                            {
                                EdiReference = data.EdiReference,
                                ShipmentNumber = data.ShipmentNumber,
                                DateTime = data.DateTime,
                                ReferenceNumber = data.ReferenceNumber,
                                LoadingDate = order.LoadingDate,
                                UnloadingDate = order.UnloadingDate,
                                PrimaryReference = order.PrimaryReference,
                                StatusCode = order.StatusCode,
                                OrderNumber = order.OrderNumber,
                                OrderlineId = line.OrderlineId,
                                ItemCode = line.ItemCode,
                                OrderlineQuantity = line.OrderlineQuantity,
                                SkuCode = detail.SkuCode,
                                LotCode = detail.LotCode,
                                PalletQuantity = detail.PalletQuantity
                            };

                            _SSCCRepository.Insert(item);
                        }
                    }
                }

                return Ok(data);

            }
            catch (System.Exception ex)
            {
                logger.Log(ErrorType.ERR, "Zwaluw SSCC", RequestContext.Principal.Identity.Name, jsonData + ":" + ex.ToString(), "api/sscc/zwaluw/create");

                return InternalServerError(ex);
            }
        }
    }
}
