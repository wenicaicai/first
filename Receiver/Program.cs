using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using static System.Console;

namespace Receiver
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

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                 {
                     var body = ea.Body;
                     var message = Encoding.UTF8.GetString(body);
                     WriteLine("[x] Received {0},", message);
                 };

                channel.BasicConsume(queue: "hello",
                    autoAck: true,
                    consumer: consumer);

                WriteLine("Press [enter] to exit.");
                ReadLine();

            }
        }
    }
}
