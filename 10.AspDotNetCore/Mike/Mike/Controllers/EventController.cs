using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mike.Application.Share.Dtos.Event;
using Mike.Application.Share.Interface;
using Mike.Controllers.Common;
using Mike.Models.Common.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mike.Controllers
{
    public class EventController : BaseApiController
    {
        private readonly IEventService _eventService;
        private readonly ILoggerManager _logger;

        public EventController(IEventService eventService, ILoggerManager logger)
        {
            _eventService = eventService;
            _logger = logger;
        }


        // GET event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents([FromQuery] EventParameters eventParameters)
        {
            var events = await _eventService.GetPagedEvent(eventParameters);

            var metadata = new
            {
                events.TotalCount,
                events.PageSize,
                events.CurrentPage,
                events.TotalPages,
                events.HasNext,
                events.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            _logger.LogInfo($"Returned {events.TotalCount} Events from database.");

            return Ok(events);
        }

        // GET event/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _eventService.GetEventById(id);
                if (res != null) return Ok(res);
                _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST event
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditEventDto input)
        {
            try
            {
                var res = await _eventService.CreateOrEdit(input);
                if (res != null) return Ok(res);
                _logger.LogError("Event object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE event/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _eventService.Delete(id);
                if (res != null) return Ok(res);
                _logger.LogError("Event object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
