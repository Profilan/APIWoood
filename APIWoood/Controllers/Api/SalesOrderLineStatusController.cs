﻿using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Models;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace APIWoood.Controllers.Api
{
    public class SalesOrderLineStatusController : ApiController
    {
        private readonly SalesOrderLineStatusRepository _salesOrderLineStatusRepository = new SalesOrderLineStatusRepository();
        private readonly UserRepository _userRepository = new UserRepository();

        [Route("api/sales-orderline-status/dutchned")]
        [HttpPost]
        [Authorize]
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

                var salesOrderLineStatus = new SalesOrderLineStatus()
                {
                    Carrier = "999068",
                    SalesOrderLineId = data.OrderLineId,
                    OrderLineStatus = data.Status,
                    TransactionDate = DateTime.Parse(data.Date, null, System.Globalization.DateTimeStyles.RoundtripKind),
                    OrderLineStatusDescription = data.Data,
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
