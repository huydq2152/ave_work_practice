using Mike.Models.Common.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Mike.Application.Share.Dtos.Document
{
    public class DocumentDto: DtoBase
    {
        public string Image { get; set; }

        public string FileUrl { get; set; }

        public int DocumentCategoryId { get; set; }
    }
}
