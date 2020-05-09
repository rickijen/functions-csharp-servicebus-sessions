using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Edwards.Function
{
    public class SessionTrigger01
    {
        private readonly IOrderedListClient _client;
        public SessionTrigger01(IOrderedListClient client) 
        {
            _client = client;
        }
        [FunctionName("SessionTrigger-01")]
        public async Task Run(
            [ServiceBusTrigger("mq-01", Connection = "integrationtest01_RootManageSharedAccessKey_SERVICEBUS", IsSessionsEnabled = true)]
            Message message,
            Int32 deliveryCount,
            DateTime enqueuedTimeUtc,
            string messageId,              
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {Encoding.UTF8.GetString(message.Body)}");
            log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
            log.LogInformation($"DeliveryCount={deliveryCount}");
            log.LogInformation($"MessageId={messageId}");

            await _client.PushData(message.SessionId, Encoding.UTF8.GetString(message.Body));
        }
    }

        public class SessionTrigger02
    {
        private readonly IOrderedListClient _client;
        public SessionTrigger02(IOrderedListClient client) 
        {
            _client = client;
        }
        [FunctionName("SessionTrigger-02")]
        public async Task Run(
            [ServiceBusTrigger("mq-02", Connection = "integrationtest01_RootManageSharedAccessKey_SERVICEBUS", IsSessionsEnabled = true)]
            Message message,
            Int32 deliveryCount,
            DateTime enqueuedTimeUtc,
            string messageId, 
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {Encoding.UTF8.GetString(message.Body)}");
            log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
            log.LogInformation($"DeliveryCount={deliveryCount}");
            log.LogInformation($"MessageId={messageId}");

            await _client.PushData(message.SessionId, Encoding.UTF8.GetString(message.Body));
        }
    }
}
