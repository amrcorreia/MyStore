using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Models
{
    public class LoginViewModel
    {
        
        [Required]
        [EmailAddress]
        public string Username { get; set; }


        [Required]
        [MinLength(6)]
        public string Password { get; set; }


        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }


        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
