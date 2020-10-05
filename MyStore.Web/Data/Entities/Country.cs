using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data.Entities
{
    public class Country : IEntity
    {
        public int Id { get; set; }


        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters.")]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }


        [Display(Name = "Cities")]
        public int NumberCities { get { return this.Cities == null ? 0 : this.Cities.Count; } }


        public DateTime CreatedDate { get; set; }


        public DateTime? UpdatedDate { get; set; }


        public User CreatedBy { get; set; }


        public User ModifiedBy { get; set; }
    }
}
