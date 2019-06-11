using System.ComponentModel.DataAnnotations;

namespace GamesWebsite.ViewModels
{
    public class BrandVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }
    }
}