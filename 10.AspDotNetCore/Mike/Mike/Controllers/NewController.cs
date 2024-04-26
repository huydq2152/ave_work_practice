using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mike.Application.Share.Dtos.New;
using Mike.Application.Share.Interface;
using Mike.Controllers.Common;
using Mike.Models.Common.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mike.Controllers
{
    public class NewController : BaseApiController
    {
        private readonly INewService _newService;
        private readonly ILoggerManager _logger;

        public NewController(INewService newService, ILoggerManager logger)
        {
            _newService = newService;
            _logger = logger;
        }


        // GET new
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewDto>>> GetNews([FromQuery] NewParameters newParameters)
        {
            var news = await _newService.GetPagedNew(newParameters);

            var metadata = new
            {
                news.TotalCount,
                news.PageSize,
                news.CurrentPage,
                news.TotalPages,
                news.HasNext,
                news.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            _logger.LogInfo($"Returned {news.TotalCount} News from database.");

            return Ok(news);
        }

        // GET new/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _newService.GetNewById(id);
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

        // POST new
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditNewDto input)
        {
            try
            {
                var res = await _newService.CreateOrEdit(input);
                if (res != null) return Ok(res);
                _logger.LogError("New object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE new/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _newService.Delete(id);
                if (res != null) return Ok(res);
                _logger.LogError("New object sent from client is null.");
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
