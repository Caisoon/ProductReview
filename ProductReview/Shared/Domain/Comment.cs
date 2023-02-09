using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Shared.Domain
{
    public class Comment : BaseDomainModel
    {
        [Required]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "maximum {1} characters allowed")]
        public string Body { get; set; }
    }
}
