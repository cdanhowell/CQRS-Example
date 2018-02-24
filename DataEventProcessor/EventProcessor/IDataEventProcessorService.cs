using DataEventProcessor.Models;

namespace DataEventProcessor.EventProcessor
{
    public interface IDataEventProcessorService
    {
        void Process(DataEventModel dataEventModel);
    }
}