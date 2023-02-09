using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Shared.Domain
{
    public class Review : BaseDomainModel
    {
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "maximum {1} characters allowed")]
        public string Body { get; set; }
    }
}
