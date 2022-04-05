using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ
{
    public class Consumer
    {
        public static void Consume(string orderQueue)
        {
            RabbitMQService _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine("{0} nolu sipariş maili gönderildi.", orderQueue, message);
                    };
                    //channel.BasicConsume(orderQueue, true, consumer);
                    Console.ReadLine();


                }
            }

        }
    }
}
