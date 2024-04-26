namespace Mike.Application.Share.Dtos.How
{
    public class CreateOrEditHowDto
    {
        public int? Id { get; set; }
        public string Author { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
