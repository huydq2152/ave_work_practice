using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mike.Application.Share.Dtos.DocumentCategory;
using Mike.Application.Share.Interface;
using Mike.Controllers.Common;

namespace Mike.Controllers
{
    public class DocumentCategoryController : BaseApiController
    {
        private readonly IDocumentCategoryService _documentCategoryService;
        private readonly ILoggerManager _logger;

        public DocumentCategoryController(IDocumentCategoryService documentCategoryService, ILoggerManager logger)
        {
            _documentCategoryService = documentCategoryService;
            _logger = logger;
        }

        // GET documentCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentCategoryDto>>> GetAll()
        {
            try
            {
                var res = await _documentCategoryService.GetAll();
                _logger.LogInfo($"Returned {res.Count} owners from database.");
                return Ok(res);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET documentCategory/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _documentCategoryService.GetDocumentCategoryById(id);
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

        // POST documentCategory
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditDocumentCategoryDto input)
        {
            try
            {
                var res = await _documentCategoryService.CreateOrEdit(input);
                if (res != null) return Ok(res);
                _logger.LogError("DocumentCategory object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE documentCategory/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _documentCategoryService.Delete(id);
                if (res != null) return Ok(res);
                _logger.LogError("DocumentCategory object sent from client is null.");
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
