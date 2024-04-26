using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mike.Application.Share.Dtos.Navigation;
using Mike.Application.Share.Interface;
using Mike.Controllers.Common;

namespace Mike.Controllers
{
    public class NavigationController : BaseApiController
    {
        private readonly INavigationService _navigationService;
        private readonly ILoggerManager _logger;

        public NavigationController(INavigationService navigationService, ILoggerManager logger)
        {
            _navigationService = navigationService;
            _logger = logger;
        }

        // GET navigation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NavigationDto>>> GetAll()
        {
            try
            {
                var res = await _navigationService.GetAll();
                _logger.LogInfo($"Returned {res.Count} owners from database.");
                return Ok(res);
            }
            catch 
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET navigation/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _navigationService.GetNavigationById(id);
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

        // POST navigation
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditNavigationDto input)
        {
            try
            {
                var res = await _navigationService.CreateOrEdit(input);
                if (res != null) return Ok(res);
                _logger.LogError("Navigation object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch 
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE navigation/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _navigationService.Delete(id);
                if (res != null) return Ok(res);
                _logger.LogError("Navigation object sent from client is null.");
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
