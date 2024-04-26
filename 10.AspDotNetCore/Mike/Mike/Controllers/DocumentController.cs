using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mike.Application.Share.Dtos.Document;
using Mike.Application.Share.Interface;
using Mike.Controllers.Common;
using Mike.Models.Common.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mike.Controllers
{
    public class DocumentController : BaseApiController
    {
        private readonly IDocumentService _documentService;
        private readonly ILoggerManager _logger;

        public DocumentController(IDocumentService documentService, ILoggerManager logger)
        {
            _documentService = documentService;
            _logger = logger;
        }


        // GET Document
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentDto>>> GetDocuments([FromQuery] DocumentParameters documentParameters)
        {
            var document = await _documentService.GetPagedDocumentByDocumentCategory(documentParameters);

            var metadata = new
            {
                document.TotalCount,
                document.PageSize,
                document.CurrentPage,
                document.TotalPages,
                document.HasNext,
                document.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            _logger.LogInfo($"Returned {document.TotalCount} Documents from database.");

            return Ok(document);
        }

        // GET Document/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var res = await _documentService.GetDocumentById(id);
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

        // POST Document
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit([FromBody] CreateOrEditDocumentDto input)
        {
            try
            {
                var res = await _documentService.CreateOrEdit(input);
                if (res != null) return Ok(res);
                _logger.LogError("Document object sent from client is null.");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch
            {
                _logger.LogInfo($"Server Error");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("/UploadFile")]
        public async Task<ActionResult> PostFile([FromForm] FileUploadRequest fileUpload)
        {
            try
            {
                await _documentService.PostFile(fileUpload);
                return Ok();
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE Document/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _documentService.Delete(id);
                if (res != null) return Ok(res);
                _logger.LogError("Document object sent from client is null.");
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
