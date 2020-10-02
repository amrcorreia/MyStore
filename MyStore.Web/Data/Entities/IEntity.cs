using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data.Entities
{
    public interface IEntity
    {
        int Id { get; set; }

        //User CreatedBy { get; set; }


        DateTime CreatedDate { get; set; }


        DateTime? UpdatedDate { get; set; }


        //User ModifiedBy { get; set; }
    }
}
