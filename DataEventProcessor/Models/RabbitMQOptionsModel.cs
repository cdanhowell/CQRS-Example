using System;
using System.Collections.Generic;
using System.Text;

namespace DataEventProcessor.Models
{
    public class RabbitMQOptionsModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Hostname { get; set; }
        public Uri Uri { get; set; }
        public string Virtualhost { get; set; }
        public string DataEventQueueName { get; set; }
    }
}
