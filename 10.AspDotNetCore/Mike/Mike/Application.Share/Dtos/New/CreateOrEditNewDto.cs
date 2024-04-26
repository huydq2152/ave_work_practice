using Mike.Models.Common.Dtos;
using System;

namespace Mike.Application.Share.Dtos.New
{
    public class CreateOrEditNewDto : CreateOrEditDtoBase
    {
        public string Content { get; set; }

        public string Image { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
