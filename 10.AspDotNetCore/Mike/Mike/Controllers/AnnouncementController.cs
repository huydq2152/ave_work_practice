using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mike.Application.Services;
using Mike.Application.Share.Dtos.Announcement;
using Mike.Application.Share.Interface;
using Mike.Controllers.Common;
using Mike.Models.Common.Helpers;
using Newtonsoft.Json;

namespace Mike.Controllers
{

    public class AnnouncementController : BaseApiController
    {
        private readonly IAnnouncementService _announcementService;
        private readonly ILoggerManager _logger;

        public AnnouncementController(IAnnouncementService announcementService, ILoggerManager logger)
        {
            _announcementService = announcementService;
            _logger = logger;
        }


        // GET announcement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnouncementDto>>> GetAnnouncements([FromQuery] AnnouncementParameters announcementParameters)
        {
            var announcement = await _announcementService.GetPagedAnnouncement(announcementParameters);

            var metadata = new
            {
                announcement.TotalCount,
                announcement.PageSize,
                announcement.CurrentPage,
                announcement.TotalPages,
                announcement.HasNext,
                announcement.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            _logger.LogInfo($"Returned {announcement.TotalCount} Announcements from database.");

            return Ok(announcement);
        }

        // GET announcement/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _announcementService.GetAnnouncementById(id);
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

        // POST announcement
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditAnnouncementDto input)
        {
            try
            {
                var res = await _announcementService.CreateOrEdit(input);
                if (res != null) return Ok(res);
                _logger.LogError("Announcement object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE announcement/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _announcementService.Delete(id);
                if (res != null) return Ok(res);
                _logger.LogError("Announcement object sent from client is null.");
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
