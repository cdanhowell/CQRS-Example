using System;
using System.Collections.Generic;
using System.Text;
using DataEventProcessor.EventProcessor;
using DataEventProcessor.Subscribers;
using RabbitMQ.Client;

namespace DataEventProcessor.Listeners
{
    public class DataEventListener : IEventListener
    {
        private IEventSubscriber subscriber;
        private IDataEventProcessorService processorService;

        public DataEventListener(IEventSubscriber subscriber, IDataEventProcessorService processorService)
        {
            this.subscriber = subscriber;
            this.processorService = processorService;

            Init();
        }

        private void Init()
        {
            this.subscriber.DataEventReceived += (data) =>
            {
                processorService.Process(data);
            };
        }

        public void Start()
        {
            subscriber.Subscribe();
        }

        public void Stop()
        {
            subscriber.Unsubscribe();
        }
    }
}
