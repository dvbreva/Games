namespace ApplicationServices.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PlayerCount { get; set; }

        public BrandDto Brand { get; set; }

        public KindDto Kind { get; set; }

    }
}
