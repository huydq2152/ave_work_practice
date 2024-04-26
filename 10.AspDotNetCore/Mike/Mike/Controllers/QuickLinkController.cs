using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mike.Application.Share.Dtos.QuickLink;
using Mike.Application.Share.Interface;
using Mike.Controllers.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mike.Controllers
{
    public class QuickLinkController : BaseApiController
    {
        private readonly IQuickLinkService _quickLinkService;
        private readonly ILoggerManager _logger;

        public QuickLinkController(IQuickLinkService quickLinkService, ILoggerManager logger)
        {
            _quickLinkService = quickLinkService;
            _logger = logger;
        }

        // GET quickLink
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuickLinkDto>>> GetAll()
        {
            try
            {
                var res = await _quickLinkService.GetAll();
                _logger.LogInfo($"Returned {res.Count} owners from database.");
                return Ok(res);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET quickLink/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _quickLinkService.GetQuickLinkById(id);
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

        // POST quickLink
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditQuickLinkDto input)
        {
            try
            {
                var res = await _quickLinkService.CreateOrEdit(input);
                if (res != null) return Ok(res);
                _logger.LogError("QuickLink object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE quickLink/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _quickLinkService.Delete(id);
                if (res != null) return Ok(res);
                _logger.LogError("QuickLink object sent from client is null.");
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
