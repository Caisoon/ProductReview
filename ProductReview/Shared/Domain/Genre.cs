using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Shared.Domain
{
    public class Genre : BaseDomainModel
    {
        [Required]
        public string Name { get; set; }
    }
}
