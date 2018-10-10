using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services.Interfaces;
using APIWoood.Logic.SharedKernel;
using System;

namespace APIWoood.Logic.Services
{
    public class SystemLogger : ILogger
    {
        public void Log(ErrorType errorType, string message, string userName, string detail, string url, DateTime? startDate = null)
        {
            var _logRepository = new LogRepository();
            var _userRepository = new UserRepository();
            var _urlRepository = new UrlRepository();

            var _user = _userRepository.GetByUsername(userName);

            if (errorType == ErrorType.INFO)
            {
                var _url = _urlRepository.GetByName(url);
                _url.Hits += 1;
                _urlRepository.Update(_url);
            }
            detail = "Username: " + userName + ": " + detail;

            DateTime start = startDate ?? DateTime.Now;
            var duration = (DateTime.Now - start).TotalMilliseconds;

            var log = new Log(DateTime.Now, (int)errorType, message, Enum.GetName(typeof(ErrorType), (int)errorType), url, detail, false, _user.Id, duration);

            _logRepository.Insert(log);
        }
    }
}
