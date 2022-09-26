using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using APIWoood.Filters;
using APIWoood.Logic.Services.Interfaces;
using APIWoood.Logic.MessageBrokers.Publishers;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class SalesOrderLineStatusController : ApiController
    {
        private readonly SalesOrderLineStatusRepository _salesOrderLineStatusRepository = new SalesOrderLineStatusRepository();
        private readonly UserRepository _userRepository = new UserRepository();
        private ILogger logger = new RabbitMQLogger(MessageBrokerPublisherFactory.Create(Logic.SharedKernel.Enums.MessageBrokerType.RabbitMq));

        [Route("api/sales-orderline-status/dutchned")]
        [HttpPost]
         public IHttpActionResult CreateSalesOrderLineStatusDutchNed([FromBody]DutchNedSalesOrderLineStatus data, string apiKey)
        {
            try
            {
                // Check the api key
                var user = _userRepository.GetByUsername(User.Identity.Name);
                if (user.ApiKey != apiKey)
                {
                    return Unauthorized();
                }

                var description = "";
                try
                {
                    switch (data.Status)
                    {
                        case 200:
                            description = data.Data.TrackingCode;
                            break;
                        case 110:
                            description = data.Data.Date;
                            break;
                        case 115:
                            description = data.Data.TimeFrom + " - " + data.Data.TimeTill;
                            break;
                        default:
                            description = data.Data.Notes != null ? data.Data.Notes : "";
                            break;
                    }
                }
                catch
                {
                    description = "";
                }
                

                var salesOrderLineStatus = new SalesOrderLineStatus()
                {
                    Carrier = "999068",
                    SalesOrderLineId = data.OrderLineId,
                    OrderId = data.DutchNedDeliveryOrderId,
                    PackageId = data.DutchNedPackageId,
                    OrderLineStatus = data.Status,
                    TransactionDate = DateTime.Parse(data.Date, null, System.Globalization.DateTimeStyles.RoundtripKind),
                    DeliveryData = JsonConvert.SerializeObject(data),
                    OrderLineStatusDescription = description
                };

                _salesOrderLineStatusRepository.Insert(salesOrderLineStatus);

                logger.Log(ErrorType.INFO, "CreateSalesOrderLineStatusDutchNed()", RequestContext.Principal.Identity.Name, salesOrderLineStatus.DeliveryData, "api/sales-orderline-status/dutchned");

                return Ok(salesOrderLineStatus);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "CreateSalesOrderLineStatusDutchNed()", RequestContext.Principal.Identity.Name, e.Message, "api/sales-orderline-status/dutchned");

                return BadRequest(e.Message);
            }
        }

    }
}
