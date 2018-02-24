using System.Collections.Generic;

namespace DataEventProcessor.EventProcessor
{
    public class ProcessorConfiguration
    {
        public IEnumerable<ProcessorConfigurationItem> ConfigItems { get; internal set; }
    }
}