using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mike.Application.Share.Dtos.VideoGallery;
using Mike.Application.Share.Interface;
using Mike.Models.Common.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mike.Controllers.Common;

namespace Mike.Controllers
{
    public class VideoGalleryController : BaseApiController
    {
        private readonly IVideoGalleryService _videoGalleryService;
        private readonly ILoggerManager _logger;

        public VideoGalleryController(IVideoGalleryService videoGalleryService, ILoggerManager logger)
        {
            _videoGalleryService = videoGalleryService;
            _logger = logger;
        }


        // GET videoGallery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGalleryDto>>> GetVideoGalleries([FromQuery] VideoGalleryParameters videoGalleryParameters)
        {
            var videoGallery = await _videoGalleryService.GetPagedVideoGallery(videoGalleryParameters);

            var metadata = new
            {
                videoGallery.TotalCount,
                videoGallery.PageSize,
                videoGallery.CurrentPage,
                videoGallery.TotalPages,
                videoGallery.HasNext,
                videoGallery.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            _logger.LogInfo($"Returned {videoGallery.TotalCount} VideoGalleries from database.");

            return Ok(videoGallery);
        }

        // GET videoGallery/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _videoGalleryService.GetVideoGalleryById(id);
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

        // POST videoGallery
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditVideoGalleryDto input)
        {
            try
            {
                var res = await _videoGalleryService.CreateOrEdit(input);
                if (res != null) return Ok(res);
                _logger.LogError("VideoGallery object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE videoGallery/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _videoGalleryService.Delete(id);
                if (res != null) return Ok(res);
                _logger.LogError("VideoGallery object sent from client is null.");
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
