using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APITaskManagement.Web.Controllers.Api
{
    public class LogController : ApiController
    {
        private readonly IRepository<Log, int> _logRepository;

        public LogController()
        {
            _logRepository = new LogRepository();
        }

        // GET api/<controller>
        public IEnumerable<Log> Get()
        {
            var logs = _logRepository.List();

            return logs;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var log = _logRepository.GetById(id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }
    }
}