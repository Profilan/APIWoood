using APIWoood.Logic.MessageBrokers.Models;
using APIWoood.Logic.MessageBrokers.Publishers;
using APIWoood.Logic.Services.Interfaces;
using APIWoood.Logic.SharedKernel;
using System;
using System.Text;
using System.Text.Json;

namespace APIWoood.Logic.Services
{
    internal class LogMessage
    {
        public ErrorType ErrorType { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string Detail { get; set; }
        public string Url { get; set; }
        public DateTime? TimeStamp { get; set; }
    }

    public class RabbitMQLogger : ILogger
    {
        private readonly PublisherBase _publisher;

        public RabbitMQLogger(PublisherBase publisher)
        {
            _publisher = publisher;
        }

        public void Log(ErrorType errorType, string message, string userName, string detail, string url, DateTime? startDate = null)
        {
            var messageId = Guid.NewGuid().ToString("N");
            var logMessage = new LogMessage
            {
                Source = System.Environment.GetEnvironmentVariable("COMPUTERNAME"),
                ErrorType = errorType,
                Message = message,
                UserName = userName,
                Detail = detail,
                Url = url,
                TimeStamp = DateTime.Now,
            };
            var logMessageJson = JsonSerializer.Serialize(logMessage);
            var messageBytes = Encoding.UTF8.GetBytes(logMessageJson);
            var brokerMessage = new Message(messageBytes, messageId, "application/json");
            _publisher.Publish(brokerMessage);
        }
    }
}
