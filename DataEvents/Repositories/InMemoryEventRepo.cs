using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataEvents.Models;

namespace DataEvents.Repositories
{
    public class InMemoryEventRepo : IDataEventsRepo
    {
        private static List<DataEventModel> repo = new List<DataEventModel>();

        public DataEventModel CreateEvent(DataEventModel eventModel)
        {
            eventModel.EventId = Guid.NewGuid();
            repo.Add(eventModel);
            return eventModel;
        }

        public DataEventModel GetById(Guid eventId)
        {
            return repo.Find(item => item.EventId == eventId);
        }
    }
}
