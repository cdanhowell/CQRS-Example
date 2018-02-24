using Newtonsoft.Json.Linq;
using System;

namespace DataEventProcessor.Models
{
    public class DataEventServiceModel
    {
        public Guid? EventId { get; set; }
        public int ProcessorConfigId { get; set; }

        public JToken Payload { get; set; }
    }
}