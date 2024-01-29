using Confluent.Kafka;
using N5TLTest.configuracion;
using N5TLTest.Dtos;
using N5TLTest.Handlers.ports;
using System.Text.Json;

namespace N5TLTest.Services
{
    public class KafkaProducerService : IEventBrokerService
    {
        private const string topic = "permission-topic"; // Replace with your topic name
        ProducerConfig config;

        private readonly ILogger<KafkaProducerService> _logger;

        public KafkaProducerService(ILogger<KafkaProducerService> logger)
        {
            _logger = logger;
            config = KafkaProducerConfiguration.GetConfig();
        }

        public async Task SendEvent(string message)
        {
            string topic = "permission-topic";
            string msg = JsonSerializer.Serialize(new PermissionEvent
            {
                Id = Guid.NewGuid(),
                Action = message
            });
            using var producer = new ProducerBuilder<Null, string>(config).Build();
            var deliveryReport = await producer.ProduceAsync(topic, new Message<Null, string>{ Value = msg });

            _logger.LogInformation($"Produced message to {deliveryReport.Topic} partition {deliveryReport.Partition} @ offset {deliveryReport.Offset}");
        }
    }
}
