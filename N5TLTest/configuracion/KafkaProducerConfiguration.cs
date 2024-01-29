using Confluent.Kafka;

namespace N5TLTest.configuracion
{
    public static class KafkaProducerConfiguration
    {
        public static ProducerConfig GetConfig()
        {
            return new ProducerConfig
            {
                BootstrapServers = "localhost:29092,localhost:39092", // Replace with your Kafka broker address
                ClientId = "KafkaExampleProducer",
            };
        }
    }
}
