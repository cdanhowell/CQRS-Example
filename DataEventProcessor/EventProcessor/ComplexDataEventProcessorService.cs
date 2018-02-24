using DataEventProcessor.Models;
using DataEventProcessor.ServiceClients;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DataEventProcessor.EventProcessor
{
    public class ComplexDataEventProcessorService : IDataEventProcessorService
    {
        private IProcessorConfigServiceClient configClient;
        private Dictionary<Type, ISource> typeToSourceDictionary;

        public ComplexDataEventProcessorService(IProcessorConfigServiceClient configClient)
        {
            this.configClient = configClient;
            this.typeToSourceDictionary = new Dictionary<Type, ISource>();
        }

        public void Process(DataEventModel dataEventModel)
        {
            ProcessorConfiguration processorConfig = configClient.GetConfigAsync(dataEventModel.DataEvent.ProcessorConfigId).Result;

            var data = dataEventModel.DataEvent.Payload.ToObject<Dictionary<String, String>>();

            foreach (ProcessorConfigurationItem configItem in processorConfig.ConfigItems)
            {
                Type sourceType = Type.GetType(configItem.Source);
                // Need to handle get type misses......
                // Could also dynamically load assemblies and types from those assemblies

                ISource source;



                if (!typeToSourceDictionary.ContainsKey(sourceType) || typeToSourceDictionary[sourceType] == null)
                {
                    source = (ISource)Activator.CreateInstance(sourceType);
                    typeToSourceDictionary.Add(sourceType, source);
                }
                else
                {
                    source = typeToSourceDictionary[sourceType];
                }


                if (configItem.ActionType == ActionTypes.GetData)
                {
                    source.GetData(out data);
                }
            }

            Console.WriteLine(JsonConvert.SerializeObject(dataEventModel));
        }

        public Task ProcessAsync(DataEventModel dataEventModel)
        {
            ProcessAsync(dataEventModel);
            return Task.FromResult(0);
        }
    }
}
