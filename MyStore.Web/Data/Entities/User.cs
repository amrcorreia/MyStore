using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data.Entities
{
    public class User : IdentityUser
    {
        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters.")]
        public string Name { get; set; }

        //[MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters.")]
        //public string LastName { get; set; }


        //[MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters.")]
        //public string Address { get; set; }
                     

        //public int CityId { get; set; }


        //public City City { get; set; }


        //[Display(Name = "Full name")]
        //public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }

        [RegularExpression(@"\d{9}",
         ErrorMessage = "Must insert the {0} correct.")]
        [Display(Name = "Value Added Tax")]
        public int VAT { get; set; }
    }
}
