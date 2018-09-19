using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services.Interfaces;
using APIWoood.Logic.SharedKernel;
using System;

namespace APIWoood.Logic.Services
{
    public class SystemLogger : ILogger
    {
        public void Log(ErrorType errorType, string message, string userName, string detail, string url)
        {
            var _logRepository = new LogRepository();
            var _userRepository = new UserRepository();

            var user = _userRepository.GetByUsername(userName);

            detail = "Username: " + userName + ": " + detail;

            var log = new Log(DateTime.Now, (int)errorType, message, Enum.GetName(typeof(ErrorType), (int)errorType), url, detail, false, user.Id);

            _logRepository.Insert(log);
        }
    }
}
