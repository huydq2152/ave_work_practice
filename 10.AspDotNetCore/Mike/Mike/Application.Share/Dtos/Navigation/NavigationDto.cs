using Mike.Models.Common.Dtos;

namespace Mike.Application.Share.Dtos.Navigation
{
    public class NavigationDto : DtoBase
    {
        public string Slug { get; set; }

        public string Url { get; set; }

        public bool IsActive { get; set; }

        public int Order { get; set; }
    }
}
