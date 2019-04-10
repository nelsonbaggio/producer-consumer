using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

using Resource;

namespace Consumer
{
    class Receiver
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                    var database = new Database().Connect();
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, input) =>
                    {
                        var body = input.Body;
                        var message = Encoding.UTF8.GetString(body);

                        database.From("messages").Create("collectionTest", "text", message);

                        Console.WriteLine(" [x] Received: {0}", message);
                    };

                    channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);


                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
