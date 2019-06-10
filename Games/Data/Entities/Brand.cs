using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        public string Country { get; set; }

        [Required]
        [MinLength(1)]
        public string Description { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}