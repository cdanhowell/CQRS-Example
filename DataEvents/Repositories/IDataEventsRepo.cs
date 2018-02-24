using System;
using DataEvents.Models;

namespace DataEvents.Repositories
{
    public interface IDataEventsRepo
    {
        DataEventModel GetById(Guid eventId);
        DataEventModel CreateEvent(DataEventModel eventModel);
    }
}