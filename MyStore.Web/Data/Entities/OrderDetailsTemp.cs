using MyStore.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data.Entities
{
    public class OrderDetailsTemp : IEntity
    {

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public User CreatedBy { get; set; }


        public User ModifiedBy { get; set; }


        [Required]
        public User User { get; set; }


        [Required]
        public Product Product { get; set; }


        [DisplayFormat(DataFormatString ="{0:C2}")]
        public decimal Price { get; set; }



        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Value { get { return this.Price * (decimal)this.Quantity; } }

        
    }
}
