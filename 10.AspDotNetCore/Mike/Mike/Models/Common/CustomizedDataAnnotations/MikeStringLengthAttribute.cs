using System;
using System.ComponentModel.DataAnnotations;

namespace Mike.Models.Common.CustomizedDataAnnotations
{
    public class MikeStringLengthAttribute : StringLengthAttribute
    {
        public MikeStringLengthAttribute(int maximumLength) : base(maximumLength)
        {
        }

        public override bool IsValid(object value)
        {
            var val = Convert.ToString(value);
            if (val.Length < MinimumLength)
                ErrorMessage = $"Length must be grater than {MinimumLength}";
            if (val.Length > MaximumLength)
                ErrorMessage = $"Maximum must be less than {MaximumLength}";
            return base.IsValid(value);
        }
    }
}
