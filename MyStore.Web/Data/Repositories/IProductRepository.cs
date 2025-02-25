﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MyStore.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboProducts();

        /// <summary>
        /// delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteProductAsync(int id);
    }
}
