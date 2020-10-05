using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Helpers
{
    public interface ICombosHelper
    {
        /// <summary>
        /// Populate countries combobox
        /// </summary>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetComboCountries();

        /// <summary>
        /// Populate cities combobox
        /// </summary>
        /// <param name="conuntryId"></param>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetComboCities(int conuntryId);
    }
}
