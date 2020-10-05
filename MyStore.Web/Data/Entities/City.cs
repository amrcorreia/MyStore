using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data.Entities
{
    public class City : IEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }


        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        public User CreatedBy { get; set; }


        public User ModifiedBy { get; set; }


        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters.")]
        [Required]
        [Display(Name= "City")]
        public string Name { get; set; }
    }
}
