using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomtomECommerce.RabbitMQ
{
    public class Publisher
    {

        public static void Publish(string orderQueue, int order)
        {
            RabbitMQService _rabbitMQService = new RabbitMQService();

            string orderId = order.ToString();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(orderQueue, false, false, false, null);
                      channel.BasicPublish("", orderQueue, null, Encoding.UTF8.GetBytes(orderId));
                    Console.WriteLine("{0} sayılı sipariş rabbitmq kuyruğuna eklendi.", orderQueue, orderId);
                }

            }


        }
    }
}
