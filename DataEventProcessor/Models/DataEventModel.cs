using System;

namespace DataEventProcessor.Models
{
    public class DataEventModel
    {
        public Uri ResourceLink { get; set; }
        public DataEventServiceModel DataEvent { get; set; }
    }
}