using System;
using System.Collections.Generic;
using System.Text;
using DataEventProcessor.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DataEventProcessor.Subscribers
{
    public class RabbitMQDataEventSubscriber : IEventSubscriber
    {

        private RabbitMQOptionsModel rmqOptions;
        private readonly EventingBasicConsumer consumer;
        private readonly IModel channel;
        private string consumerTag;

        private ConnectionFactory connectionFactory;

        public RabbitMQDataEventSubscriber(IOptions<RabbitMQOptionsModel> rmqOptions)
        {
            this.rmqOptions = rmqOptions.Value;

            connectionFactory = new ConnectionFactory
            {
                UserName = this.rmqOptions.Username,
                Password = this.rmqOptions.Password,
                VirtualHost = this.rmqOptions.Virtualhost,
                HostName = this.rmqOptions.Hostname,
                Uri = this.rmqOptions.Uri
            };

            IConnection connection = connectionFactory.CreateConnection();
            channel = connection.CreateModel();
            consumer = new EventingBasicConsumer(channel);

            Init();
        }

        private void Init()
        {
            channel.QueueDeclare(rmqOptions.DataEventQueueName, false, false, false, null);

            consumer.Received += (ch, ea) =>
            {
                string json = Encoding.UTF8.GetString(ea.Body);
                DataEventModel eventData = JsonConvert.DeserializeObject<DataEventModel>(json);

                DataEventReceived?.Invoke(eventData);
            };
        }

        public event DataEventReceivedDelegate DataEventReceived;

        public void Subscribe()
        {
            consumerTag = channel.BasicConsume(rmqOptions.DataEventQueueName, false, consumer);
        }

        public void Unsubscribe()
        {
            channel.BasicCancel(consumerTag);
        }
    }
}
