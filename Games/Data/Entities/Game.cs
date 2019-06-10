using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Game : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int PlayerCount { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int KindId { get; set; }
        public virtual Kind Kind { get; set; }
    }
}