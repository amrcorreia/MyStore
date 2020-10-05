using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data.Entities
{
    public class ContactForm
    {
        //public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
        //public User CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public User ModifiedBy { get; set; }
    }
}
