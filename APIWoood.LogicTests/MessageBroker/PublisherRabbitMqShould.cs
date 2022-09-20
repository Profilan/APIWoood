using APIWoood.Logic.MessageBrokers.Publishers;
using APIWoood.Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace APIWoood.LogicTests.MessageBroker
{
    [TestClass]
    public class PublisherRabbitMqShould
    {
        [TestMethod]
        public void PublishLogMessage()
        {
            var publisher = MessageBrokerPublisherFactory.Create(Logic.SharedKernel.Enums.MessageBrokerType.RabbitMq);
            var logger = new RabbitMQLogger(publisher);
            logger.Log(Logic.SharedKernel.ErrorType.INFO, "PublishLogMessage()", "B_Raymond", "Dit is een test", "/api/woood-order/create", DateTime.Now);
        }
    }
}
