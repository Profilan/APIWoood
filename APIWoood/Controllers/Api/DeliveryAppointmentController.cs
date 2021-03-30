using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Models;
using System;
using System.Web.Http;
using APIWoood.Filters;
using Newtonsoft.Json;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class DeliveryAppointmentController : ApiController
    {
        private readonly DeliveryAppointmentRepository _deliveryAppointmentRepository = new DeliveryAppointmentRepository();
        private readonly UserRepository _userRepository = new UserRepository();

        [Route("api/delivery-appointment/dutchned")]
        [HttpPost]
        public IHttpActionResult CreateDeliveryAppointmentDutchNed([FromBody]DutchNedDeliveryAppointment data, string apiKey)
        {
            try
            {
                // Check the api key
                var user = _userRepository.GetByUsername(User.Identity.Name);
                if (user.ApiKey != apiKey)
                {
                    return Unauthorized();
                }

                var deliveryAppointment = new DeliveryAppointment()
                {
                    Carrier = "999068",
                    SalesOrderLineId = data.OrderLineId,
                    OrderId = data.DutchNedDeliveryOrderId,
                    PackageId = data.DutchNedPackageId,
                    DeliveryAppointmentStatus = data.Status,
                    TransactionDate = DateTime.Parse(data.Date, null, System.Globalization.DateTimeStyles.RoundtripKind),
                    Data = JsonConvert.SerializeObject(data.Data),
                };

                _deliveryAppointmentRepository.Insert(deliveryAppointment);

                return Ok(deliveryAppointment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
