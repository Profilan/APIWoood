using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
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
    public class DashboardController : ApiController
    {
        private readonly UrlRepository urlRepository;
        private readonly LogRepository logRepository;

        public DashboardController()
        {
            urlRepository = new UrlRepository();
            logRepository = new LogRepository();
        }

        [Route("api/dashboard/url-usage")]
        [HttpGet]
        public IHttpActionResult UrlUsage(Period period)
        {
            var usageUrls = new List<Url>();// urlRepository.List().OrderBy(x => x.Hits);

            var urls = urlRepository.List().OrderBy(x => x.Hits);
            foreach (var url in urls)
            {
                var logs = logRepository.ListByUrl(url.Name, period);
                var urlViewModel = new Url()
                {
                    Name = url.Name,
                    Hits = logs.Count(),
                    Id = url.Id
                };
                usageUrls.Add(urlViewModel);
            }

            return Ok(DashboardService.GetUrlUsageData(usageUrls));
        }

        [Route("api/dashboard/latest-errors")]
        [HttpGet]
        public IHttpActionResult LatestErrors(Period period = Period.month)
        {
            // Get the laters errors
            var urls = urlRepository.List();
            var logErrors = new List<UrlViewModel>();
            foreach (var url in urls)
            {
                var logs = logRepository.List(period, ErrorType.ERR, url.Name);
                if (logs.Count() > 0)
                {
                    var logViewModel = new UrlViewModel()
                    {
                        Name = url.Name,
                        ErrorCount = logs.Count()
                    };
                    logErrors.Add(logViewModel);
                }
            }

            return Ok(logErrors);
        }
    }
}
