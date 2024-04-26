using Mike.Models.Common.Dtos;
using System.ComponentModel.DataAnnotations;
using Mike.Models.Common.Helpers;
using Microsoft.AspNetCore.Http;

namespace Mike.Application.Share.Dtos.Document
{
    public class CreateOrEditDocumentDto: CreateOrEditDtoBase
    {
        public string Image { get; set; }

        public string FileUrl { get; set; }

        public int DocumentCategoryId { get; set; }
    }
}
