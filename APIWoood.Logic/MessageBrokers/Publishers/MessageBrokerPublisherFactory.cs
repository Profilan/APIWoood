using APIWoood.Logic.SharedKernel.Enums;
using APIWoood.Logic.SharedKernel.Exceptions;
using System.Configuration;

namespace APIWoood.Logic.MessageBrokers.Publishers
{
    public static class MessageBrokerPublisherFactory
    {
        public static PublisherBase Create(MessageBrokerType messageBrokerType)
        {
            switch (messageBrokerType)
            {
                case MessageBrokerType.RabbitMq:
                    string brokerConnectionString = ConfigurationManager.AppSettings["BrokerConnectionString"];
                    string brokerTopic  = ConfigurationManager.AppSettings["BrokerTopic"];
                    return new PublisherRabbitMq(brokerConnectionString, brokerTopic);
            }

            throw new MessageBrokerTypeNotSupportedException($"The MessageBrokerType: {messageBrokerType}, is not supported yet");
        }
    }
}
