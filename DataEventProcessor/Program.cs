using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using Microsoft.Extensions.Configuration;
using System.IO;
using DataEventProcessor.EventProcessor;
using DataEventProcessor.Subscribers;
using DataEventProcessor.Listeners;
using DataEventProcessor.Models;
using DataEventProcessor.ServiceClients;

namespace DataEventProcessor
{
    class Program
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            // Get configuration settings
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Get services and service provider            
            ServiceProvider serviceProvider = ConfigureServices(new ServiceCollection(), configuration);

            // Get and start the event processor
            IEventListener listener = serviceProvider.GetService<IEventListener>();
            listener.Start();

            // Configure shutdown conditions
            Console.CancelKeyPress += (sender, eArgs) =>
            {
                listener.Stop();
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            _quitEvent.WaitOne();
        }
        

        static ServiceProvider ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            // Add services here
            services.AddOptions();
            services.Configure<RabbitMQOptionsModel>(configuration.GetSection("rabbitMq"));

            services.AddSingleton<IEventListener, DataEventListener>();
            services.AddSingleton<IDataEventProcessorService, DataEventProcessorService>();
            services.AddSingleton<IEventSubscriber, RabbitMQDataEventSubscriber>();
            services.AddSingleton<IProcessorConfigServiceClient, InMemoryProcessorConfigServiceClient>();

            return services.BuildServiceProvider();
        }
    }
}
