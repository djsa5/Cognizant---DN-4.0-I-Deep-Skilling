using System;
using Confluent.Kafka;
using System.Threading.Tasks;

class ChatProducer
{
    public static async Task Main(string[] args)
    {
        var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        Console.WriteLine("Type your messages (type 'exit' to quit):");

        while (true)
        {
            var message = Console.ReadLine();
            if (message == "exit") break;

            await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
            Console.WriteLine("Message sent.");
        }
    }
}
