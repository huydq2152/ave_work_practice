using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mike.Application.Share.Dtos.ImageGallery;
using Mike.Application.Share.Interface;
using Mike.Controllers.Common;
using Mike.Models.Common.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mike.Controllers
{
    public class ImageGalleryController : BaseApiController
    {
        private readonly IImageGalleryService _imageGalleryService;
        private readonly ILoggerManager _logger;

        public ImageGalleryController(IImageGalleryService imageGalleryService, ILoggerManager logger)
        {
            _imageGalleryService = imageGalleryService;
            _logger = logger;
        }


        // GET imageGallery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageGalleryDto>>> GetImageGalleries([FromQuery] ImageGalleryParameters imageGalleryParameters)
        {
            var imageGallery = await _imageGalleryService.GetPagedImageGallery(imageGalleryParameters);

            var metadata = new
            {
                imageGallery.TotalCount,
                imageGallery.PageSize,
                imageGallery.CurrentPage,
                imageGallery.TotalPages,
                imageGallery.HasNext,
                imageGallery.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            _logger.LogInfo($"Returned {imageGallery.TotalCount} ImageGalleries from database.");

            return Ok(imageGallery);
        }

        // GET imageGallery/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _imageGalleryService.GetImageGalleryById(id);
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

        // POST imageGallery
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditImageGalleryDto input)
        {
            try
            {
                var res = await _imageGalleryService.CreateOrEdit(input);
                if (res != null) return Ok(res);
                _logger.LogError("ImageGallery object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE imageGallery/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _imageGalleryService.Delete(id);
                if (res != null) return Ok(res);
                _logger.LogError("ImageGallery object sent from client is null.");
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
