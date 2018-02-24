using System.Collections.Generic;

namespace DataEventProcessor.EventProcessor
{
    internal interface ISource
    {
        void GetData(out Dictionary<string, string> data);
    }
}