using DataEventProcessor.Models;

namespace DataEventProcessor.Subscribers
{
    public interface IEventSubscriber
    {
        event DataEventReceivedDelegate DataEventReceived;

        void Subscribe();
        void Unsubscribe();
    }

    public delegate void DataEventReceivedDelegate(DataEventModel evt);
}