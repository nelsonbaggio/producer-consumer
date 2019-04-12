using RabbitMQ.Client;
using System;
using System.IO;
using System.Text;
using System.Threading;
namespace Producer
{
    class Sender
    {
        static void Main(string[] args)
        {

            var brokerHostName = Environment.GetEnvironmentVariable("BROKER_HOST_NAME");

            var factory = new ConnectionFactory() { HostName = brokerHostName };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello", durable: false, exclusive: false,
                                autoDelete: false, arguments: null);

                    while (true)
                    {
                        string message = $"The random name is: {new Random().Next(0, 100)}";
                        
                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "", routingKey: "hello",
                                basicProperties: null, body: body);

                        Console.WriteLine(" [x] Sent: {0}", message);
                        Thread.Sleep(1000);
                    }

                }
            }
        }
    }
}
