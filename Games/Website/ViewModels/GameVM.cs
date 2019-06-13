using ApplicationServices.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Website.ViewModels
{
    public class GameVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int PlayerCount { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public BrandVM Brand { get; set; }

        [Display(Name = "Kind")]
        public int KindId { get; set; }
        public KindVM Kind { get; set; }

        public GameVM()
        {

        }

        public GameVM(GameDto gameDto)
        {
            Id = gameDto.Id;
            Name = gameDto.Name;
            Description = gameDto.Description;
            PlayerCount = gameDto.PlayerCount;
            BrandId = gameDto.Brand.Id;
            Brand = new BrandVM
            {
                Id = gameDto.Brand.Id,
                Name = gameDto.Brand.Name,
                Country = gameDto.Brand.Country,
                Description = gameDto.Brand.Description
            };
            KindId = gameDto.Kind.Id;
            Kind = new KindVM
            {
                Id = gameDto.Kind.Id,
                Name = gameDto.Kind.Name,
                Description = gameDto.Kind.Description,
                Suitability = gameDto.Kind.Suitability
            };
        }
    }
}