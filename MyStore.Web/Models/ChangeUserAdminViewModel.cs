using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyStore.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Web.Models
{
    public class ChangeUserAdminViewModel : User
    {
        
        [Required]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        public int VAT { get; set; }

        //public bool EmailConfirmed { get; set; }


        //[MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters.")]
        //public string Address { get; set; }


        //[MaxLength(20, ErrorMessage = "The field {0} only can contain {1} characters.")]
        //public string PhoneNumber { get; set; }


        //[Display(Name = "City")]
        //[Range(1, int.MaxValue, ErrorMessage = "You must select a city")]
        //public int CityId { get; set; }


        //public IEnumerable<SelectListItem> Cities { get; set; }



        //[Display(Name = "Country")]
        //[Range(1, int.MaxValue, ErrorMessage = "You must select a country")]
        //public int CountryId { get; set; }



        //public IEnumerable<SelectListItem> Countries { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
    }
}
