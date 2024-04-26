using System.ComponentModel.DataAnnotations.Schema;
using Mike.Models.Common;

namespace Mike.Models.Entities
{
    [Table("Homework10_QuickLink")]
    public class QuickLink : EntityBase
    {
        public string Image { get; set; }
    }
}
