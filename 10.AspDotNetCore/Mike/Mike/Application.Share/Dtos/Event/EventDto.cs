using Mike.Models.Common.Dtos;

namespace Mike.Application.Share.Dtos.Event
{
    public class EventDto: DtoBase
    {
        public string Start { get; set; }

        public string End { get; set; }

        public string Day { get; set; }

        public string Month { get; set; }
    }
}
