using System.ComponentModel.DataAnnotations;
using Mike.Models.Common.CustomizedDataAnnotations;

namespace Mike.Models.Common
{
    public class EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [MikeStringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int Order { get; set; }
    }
}
