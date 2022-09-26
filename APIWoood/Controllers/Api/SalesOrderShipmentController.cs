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
using APIWoood.Filters;
using APIWoood.Logic.Services.Interfaces;
using APIWoood.Logic.MessageBrokers.Publishers;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class SalesOrderShipmentController : WooodApiController
    {
        private readonly SalesOrderShipmentRepository salesOrderShipmentRepository = new SalesOrderShipmentRepository();
        private readonly UserRepository userRepository = new UserRepository();
        private ILogger logger = new RabbitMQLogger(MessageBrokerPublisherFactory.Create(Logic.SharedKernel.Enums.MessageBrokerType.RabbitMq));

        [Route("api/sales-order-shipment")]
        [HttpPost]
        public IHttpActionResult CreateSalesOrderShipment([FromBody]SalesOrderShipmentDto data, string apikey)
        {
            string apiKey;
            try
            {
                apiKey = apikey;
            }
            catch (System.Exception)
            {
                logger.Log(ErrorType.ERR, "CreateSalesOrderShipment()", RequestContext.Principal.Identity.Name, "API key is missing.", "sales-order-shipment");

                return Content(HttpStatusCode.Unauthorized, "API key is missing.");
            }

            var user = userRepository.GetByUsername(RequestContext.Principal.Identity.Name);
            if (apiKey != user.ApiKey)
            {
                logger.Log(ErrorType.ERR, "CreateSalesOrderShipment()", RequestContext.Principal.Identity.Name, "API key is not correct. Get a right API key from the service provider.", "sales-order-shipment");

                return Content(HttpStatusCode.Unauthorized, "API key is not correct. Get a right API key from the service provider.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Does the shipment already exist
                    var shipment = salesOrderShipmentRepository.GetBySkuId(data.SkuId);

                    DateTime deliveryDate;
                    DateTime.TryParse(data.DeliveryDate, out deliveryDate);

                    if (shipment == null) // new shipment
                    {
                        var newShipment = new SalesOrderShipment()
                        {
                            SkuId = data.SkuId,
                            ShipmentId = data.ShipmentId,
                            DebtorNumber = data.DebtorNumber,
                            SkuType = data.SkuType,
                            Carrier = data.Carrier,
                            DeliveryDate = deliveryDate,
                            DebtorName = data.DebtorName,
                            DelAddress = data.DelAddress,
                            DelPostcode = data.DelPostcode,
                            DelCity = data.DelCity,
                            DelCountryCode = data.DelCountryCode,
                            TrackTraceCode = data.TrackTraceCode,
                            TrackTraceUrl = data.TrackTraceUrl,
                            Status = data.Status
                        };

                        salesOrderShipmentRepository.Insert(newShipment);

                        logger.Log(ErrorType.INFO, "CreateSalesOrderShipment()", RequestContext.Principal.Identity.Name, "Shipment with SkuId " + data.SkuId + " inserted", "sales-order-shipment");

                        return Content(HttpStatusCode.Created, newShipment);
                    }
                    else // existing shipment
                    {
                        shipment.Status = data.Status;
                        shipment.TrackTraceCode = data.TrackTraceCode;
                        shipment.TrackTraceUrl = data.TrackTraceUrl;
                        shipment.DeliveryDate = deliveryDate;

                        salesOrderShipmentRepository.Update(shipment);

                        logger.Log(ErrorType.INFO, "CreateSalesOrderShipment()", RequestContext.Principal.Identity.Name, "Shipment with SkuId " + data.SkuId + " updated", "sales-order-shipment");

                        return Content(HttpStatusCode.Created, shipment);
                    }

                }
                catch (Exception e)
                {
                    logger.Log(ErrorType.ERR, "CreateSalesOrderShipment()", RequestContext.Principal.Identity.Name, e.Message, "sales-order-shipment");

                    return Content(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }
         }
    }
}
