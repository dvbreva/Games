using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Kind : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool Suitability { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
