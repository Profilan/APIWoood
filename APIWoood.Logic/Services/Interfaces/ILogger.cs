

using APIWoood.Logic.SharedKernel;
using System;

namespace APIWoood.Logic.Services.Interfaces
{
    public interface ILogger
    {
        void Log(ErrorType errorType, string message, string userName, string detail, string url, DateTime? startDate = null);
    }
}
