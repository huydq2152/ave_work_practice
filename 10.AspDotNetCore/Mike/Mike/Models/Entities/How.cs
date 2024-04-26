using Mike.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mike.Models.Entities
{
    [Table("Homework10_How")]
    public class How 
    {
        public int Id { get; set; }
        public string Author { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
