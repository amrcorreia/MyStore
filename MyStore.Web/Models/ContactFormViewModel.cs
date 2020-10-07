using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Models
{
    public class ContactFormViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The field {0} only can contains {1} characters length.")]
        public string Name { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Subject { get; set; }


        [Required]
        public string Message { get; set; }
    }
}
