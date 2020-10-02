using Microsoft.AspNetCore.Identity;
using MyStore.Web.Data.Entities;
using MyStore.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly Random _random;

        public SeedDb(DataContext context,
            IUserHelper userHelper) //recebe o DataContext
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public UserManager<User> UserManager { get; }


        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();//verifica se a base de dados está criada
            await CheckProductsAsync();

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");

            if (!_context.Countries.Any())
            {
                //var cities = new List<City>();
                //cities.Add(new City { Name = "Lisboa" });
                //cities.Add(new City { Name = "Porto" });
                //cities.Add(new City { Name = "Coimbra" });
                //cities.Add(new City { Name = "Faro" });

                _context.Countries.Add(new Country
                {
                    //Cities = cities,
                    Name = "Portugal"
                });

                await _context.SaveChangesAsync();
            }

            var user = await _userHelper.GetUserByEmailAsync("correiandreiamr@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Andreia",
                    LastName = "Correia",
                    Email = "correiandreiamr@gmail.com",
                    UserName = "correiandreiamr@gmail.com",
                    PhoneNumber = "123456789",
                    Address = "Rua JJ",
                    //CityId = _context.Countries.FirstOrDefault().Cities.FirstOrDefault().Id,
                    //City = _context.Countries.FirstOrDefault().Cities.FirstOrDefault()
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder.");
                }

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

                var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
                if (!isInRole)
                {
                    await _userHelper.AddUserToRoleAsync(user, "Admin");
                }
            }
        }

        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                var user = _context.Users.FirstOrDefault();
                this.AddProduct("Banana", user);
                this.AddProduct("Repolho", user);
                this.AddProduct("Cenoura", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
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
                User = user
            });
        }
    }
}
