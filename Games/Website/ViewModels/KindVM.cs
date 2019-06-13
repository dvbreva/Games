using System.ComponentModel.DataAnnotations;

namespace Website.ViewModels
{
    public class KindVM
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool Suitability { get; set; }

    }
}