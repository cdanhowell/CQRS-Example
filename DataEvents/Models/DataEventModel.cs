using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataEvents.Models
{
    public class DataEventModel
    {
        public Guid? EventId { get; set; }

        public JToken Payload { get; set; }
    }
}
