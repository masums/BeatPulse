﻿using BeatPulse.Core;
using BeatPulse.RabbitMQ;

namespace BeatPulse
{
    public static class BeatPulseContextExtensions
    {
        public static BeatPulseContext AddRabbitMQ(this BeatPulseContext context, string rabbitMQConnectionString, string defaultPath = "rabbitmq")
        {
            return context.AddLiveness(nameof(RabbitMQLiveness), opt =>
            {
                opt.UsePath(defaultPath);
                opt.UseLiveness(new RabbitMQLiveness(rabbitMQConnectionString));
            });
        }
    }
}
