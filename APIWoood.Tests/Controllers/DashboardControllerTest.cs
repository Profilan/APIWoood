using System;
using System.Collections.Generic;
using System.Linq;
using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIWoood.Tests.Controllers
{
    [TestClass]
    public class DashboardControllerTest
    {
        private readonly UrlRepository _urlRepository;
        private readonly LogRepository _logRepository;

        public DashboardControllerTest()
        {
            _urlRepository = new UrlRepository();
            _logRepository = new LogRepository();
        }

        [TestMethod]
        public void UrlUsage()
        {
            var usageUrls = new List<Url>();// urlRepository.List().OrderBy(x => x.Hits);

            var urls = _urlRepository.List().OrderBy(x => x.Hits);
            foreach (var url in urls)
            {
                var logs = _logRepository.ListByUrl(url.Name, Period.month);
                var urlViewModel = new Url()
                {
                    Name = url.Name,
                    Hits = logs.Count(),
                    Id = url.Id
                };
                usageUrls.Add(urlViewModel);
            }

            var data = DashboardService.GetUrlUsageData(usageUrls);

            data.Should().NotBeNullOrEmpty();
        }
    }
}
