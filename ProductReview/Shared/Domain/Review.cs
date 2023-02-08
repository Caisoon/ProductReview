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

        public string Name { get; set; }

        public string Body { get; set; }

        

        public string ProductID { get; set; }
        public virtual Product Product { get; set; }

        
    }
}