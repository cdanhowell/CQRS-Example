using DataEventProcessor.Models;
using Newtonsoft.Json;
using System;

namespace DataEventProcessor.EventProcessor
{
    public class DataEventProcessorService : IDataEventProcessorService
    {
        public void Process(DataEventModel dataEventModel)
        {
            Console.WriteLine(JsonConvert.SerializeObject(dataEventModel));
        }
    }
}
