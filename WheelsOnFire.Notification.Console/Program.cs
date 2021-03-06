﻿using MassTransit;
using WheelsOnFire.Messaging;

namespace WheelsOnFire.Notification.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Title = "Notification";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.NotificationServiceQueue, e =>
                {
                    e.Consumer<OrderRegisteredConsumer>();
                });
            });

            bus.Start();

            System.Console.WriteLine("Listening for Order registered events.. Press enter to exit");
            System.Console.ReadLine();

            bus.Stop();
        }
    }
}
