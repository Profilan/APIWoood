using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Models;
using System;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class DeliveryAppointmentController : ApiController
    {
        private readonly DeliveryAppointmentRepository _deliveryAppointmentRepository = new DeliveryAppointmentRepository();
        private readonly UserRepository _userRepository = new UserRepository();

        [Route("api/delivery-appointment/dutchned")]
        [HttpPost]
        [Authorize]
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
                    DeliveryAppointmentStatus = data.Status,
                    TransactionDate = DateTime.Parse(data.Date, null, System.Globalization.DateTimeStyles.RoundtripKind),
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
