namespace Mike.Models.Common.Dtos
{
    public class CreateOrEditDtoBase
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public int Order { get; set; }
    }
}
