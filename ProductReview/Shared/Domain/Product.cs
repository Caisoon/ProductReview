using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Shared.Domain
{
    public class Product: BaseDomainModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        [Required]
        public double ProductPrice { get; set; }

    }
}
