using System.ComponentModel.DataAnnotations;

namespace MyStore.Web.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
