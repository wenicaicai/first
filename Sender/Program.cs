using RabbitMQ.Client;
using System;
using System.Text;
using static System.Console;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                while (true)
                {
                    var input = ReadLine();
                    string message = input;
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: "hello",
                        basicProperties: null,
                        body: body);
                    WriteLine("[x] sent {0}", message);
                    WriteLine("Press [enter] to exit.");
                }
            }
        }
    }
}
