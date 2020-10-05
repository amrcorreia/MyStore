using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public User CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public User ModifiedBy { get; set; }


        [Required]
        [DisplayName("Order date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime OrderDate { get; set; }


        [DisplayName("Delivery date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? DeliveryDate { get; set; }


        [Required]
        public User User { get; set; }


        public IEnumerable<OrderDetail> Items { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int Lines { get { return this.Items == null ? 0 : this.Items.Count(); } }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Quantity => this.Items == null ? 0 : this.Items.Sum(i => i.Quantity);


        public decimal Value => this.Items == null ? 0 : this.Items.Sum(i => i.Value);

        [Required]
        [DisplayName("Order date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime? OrderDateLocal
        {
            get
            {
                if (this.Items == null)
                {
                    return null;
                }

                return this.OrderDate.ToLocalTime();
            }
        }

    }
}
