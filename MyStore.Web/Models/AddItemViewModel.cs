using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Models
{
    public class AddItemViewModel
    {
        [Display(Name = "Product")]
        [Range(1,int.MaxValue, ErrorMessage ="You must select a product.")]
        public int ProductId { get; set; }


        [Range(0.0001, double.MaxValue, ErrorMessage = "The quantity must be a positive number.")]
        public double Quantity { get; set; }


        //isto é para uma combobox renderizada que tem lá dentro os produtos 
        //-> SelectListItem(não é uma lista de produtos é uma lista já renderizada)
        public IEnumerable<SelectListItem> Products { get; set; }
    }
}
