using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataEventProcessor.EventProcessor;

namespace DataEventProcessor.ServiceClients
{
    public class InMemoryProcessorConfigServiceClient : IProcessorConfigServiceClient
    {
        public Task<ProcessorConfiguration> GetConfigAsync(int processorConfigId)
        {
            throw new NotImplementedException();
        }
    }
}
