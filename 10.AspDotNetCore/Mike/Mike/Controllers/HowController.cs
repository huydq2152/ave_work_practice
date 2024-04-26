using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mike.Application.Share.Dtos.How;
using Mike.Application.Share.Interface;
using Mike.Controllers.Common;
using Mike.Models.Common.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mike.Controllers
{
    public class HowController : BaseApiController
    {
        private readonly IHowService _howService;
        private readonly ILoggerManager _logger;

        public HowController(IHowService howService, ILoggerManager logger)
        {
            _howService = howService;
            _logger = logger;
        }


        // GET how
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HowDto>>> GetHows([FromQuery] HowParameters howParameters)
        {
            var how = await _howService.GetPagedAndFilteredHow(howParameters);

            var metadata = new
            {
                how.TotalCount,
                how.PageSize,
                how.CurrentPage,
                how.TotalPages,
                how.HasNext,
                how.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            _logger.LogInfo($"Returned {how.TotalCount} Hows from database.");

            return Ok(how);
        }

        // GET how/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _howService.GetHowById(id);
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

        // POST how
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditHowDto input)
        {
            try
            {
                var res = await _howService.CreateOrEdit(input);
                if (res != null) return Ok(res);
                _logger.LogError("How object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE how/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _howService.Delete(id);
                if (res != null) return Ok(res);
                _logger.LogError("How object sent from client is null.");
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
