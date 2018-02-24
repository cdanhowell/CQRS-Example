namespace DataEventProcessor.EventProcessor
{
    public class ProcessorConfigurationItem
    {
        public string Source { get; internal set; }
        public ActionTypes ActionType { get; internal set; }
    }
}