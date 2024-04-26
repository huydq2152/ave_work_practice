using System;
using System.ComponentModel.DataAnnotations.Schema;
using Mike.Models.Common;

namespace Mike.Models.Entities
{
    [Table("Homework10_Event")]
    public class Event : EntityBase
    {
        public string Start { get; set; }

        public string End { get; set; }

        public string Day { get; set; }

        public string Month { get; set; }
    }
}
