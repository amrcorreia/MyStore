using MyStore.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly Random _random;

        public SeedDb(DataContext context) //recebe o DataContext
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();//verifica se a base de dados está criada
            await CheckProductsAsync();
        }

        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                this.AddProduct("Banana");
                this.AddProduct("Repolho");
                this.AddProduct("Cenoura");
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            _context.Products.Add(new Product
            {
                CreatedDate = DateTime.Now.AddDays(-2),
                UpdatedDate = DateTime.Now.AddDays(0),
                Name = name,
                Price = _random.Next(10),
                LastPurchase = DateTime.Now.AddDays(-1),
                LastSale = DateTime.Now.AddDays(0),
                IsAvailable = false,
                Stock = _random.Next(1000),
            });
        }
    }
}
