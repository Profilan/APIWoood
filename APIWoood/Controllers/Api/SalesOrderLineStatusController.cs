using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Models;
using System;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class SalesOrderLineStatusController : ApiController
    {
        private readonly SalesOrderLineStatusRepository _salesOrderLineStatusRepository = new SalesOrderLineStatusRepository();

        [Route("api/sales-orderline-status/dutchned")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateSalesOrderLineStatusDutchNed([FromBody]DutchNedSalesOrderLineStatus data)
        {
            try
            {
                var salesOrderLineStatus = new SalesOrderLineStatus()
                {
                    Carrier = "900339",
                    SalesOrderLineId = data.OrderLineId,
                    OrderLineStatus = data.Status,
                    TransactionDate = DateTime.Parse(data.Date, null, System.Globalization.DateTimeStyles.RoundtripKind),
                    OrderLineStatusDescription = data.Data
                };

                _salesOrderLineStatusRepository.Insert(salesOrderLineStatus);

                return Ok(salesOrderLineStatus);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
