using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataEvents.Models;
using DataEvents.Repositories;

namespace DataEvents.Controllers
{
    [Produces("application/json")]
    [Route("api/DataEvents")]
    public class DataEventsController : Controller
    {
        private IDataEventsRepo dataEventsRepo;

        public DataEventsController(IDataEventsRepo dataEventsRepo)
        {
            this.dataEventsRepo = dataEventsRepo;
        }

        [HttpGet]
        [Route("/{eventId}")]
        public ActionResult GetById(Guid eventId)
        {
            DataEventModel dataEvent = dataEventsRepo.GetById(eventId);
            return Ok(dataEvent);
        }

        [HttpPost]
        public ActionResult PostEvent([FromBody] DataEventModel eventModel)
        {
            DataEventModel result = dataEventsRepo.CreateEvent(eventModel);
            return Created($"/api/DataEvents/{result.EventId}", result);
        }
    }
}