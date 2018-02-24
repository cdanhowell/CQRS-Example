using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataEventProcessor.EventProcessor;

namespace DataEventProcessor.ServiceClients
{
    public interface IProcessorConfigServiceClient
    {
        Task<ProcessorConfiguration> GetConfigAsync(int processorConfigId);
    }
}
