using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomtomECommerce.RabbitMQ
{
    public class Consumer
    {
        private readonly RabbitMQService _rabbitMQService;
        public Consumer(string orderQueue)
        {
            _rabbitMQService = new RabbitMQService();

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
                    channel.BasicConsume(orderQueue, true, consumer);
                    Console.ReadLine();


                }
            }

        }

    }

}
