using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Helpers
{
    public class CombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get cities combobox by country
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        //public IEnumerable<SelectListItem> GetComboCities(int countryId)
        //{
        //    var country = _context.Countries.Find(countryId);
        //    var list = new List<SelectListItem>();
        //    if (country != null)
        //    {
        //        list = country.Cities.Select(c => new SelectListItem
        //        {
        //            Text = c.Name,
        //            Value = c.Id.ToString()
        //        }).OrderBy(l => l.Text).ToList();
        //    }

        //    list.Insert(0, new SelectListItem
        //    {
        //        Text = "(Select a city...)",
        //        Value = "0"
        //    });

        //    return list;

        //}

        /// <summary>
        /// Get countries combobox
        /// </summary>
        /// <returns></returns>
        //public IEnumerable<SelectListItem> GetComboCountries()
        //{
        //    var list = _context.Countries.Select(c => new SelectListItem
        //    {
        //        Text = c.Name,
        //        Value = c.Id.ToString()

        //    }).OrderBy(l => l.Text).ToList();

        //    list.Insert(0, new SelectListItem
        //    {
        //        Text = "(Select a country...)",
        //        Value = "0"
        //    });

        //    return list;

        //}

    }
}
