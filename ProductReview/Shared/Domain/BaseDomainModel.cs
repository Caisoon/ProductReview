using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Shared.Domain
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime DateUploaded { get; set; }
        public DateTime DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
