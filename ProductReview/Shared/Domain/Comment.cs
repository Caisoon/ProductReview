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
        
        public string Name { get; set; }

        public string Body { get; set; }
    }
}