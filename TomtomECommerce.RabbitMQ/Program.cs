using System;

namespace TomtomECommerce.RabbitMQ
{
    public class Program
    {
        private static readonly string _queueName = "orderQueue";
        private static Publisher _publisher;
        private static Consumer _consumer;


        static void Main(string[] args)
        {
            _publisher = new Publisher(_queueName, orderId);
            _consumer = new Consumer(_queueName);

            Console.ReadLine();
        }
    }
}
