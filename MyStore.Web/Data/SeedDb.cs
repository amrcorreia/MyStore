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
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        //public UserManager<User> UserManager { get; }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();//verify if database exists
            await CheckRolesAsync();
            await CheckCountriesAndCitiesAsync();
            await CheckUsersAsync();
            await CheckProductsAsync();
        }

        /// <summary>
        /// Add roles
        /// </summary>
        /// <returns></returns>
        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
            await _userHelper.CheckRoleAsync("Resale");
        }

        /// <summary>
        /// Add countries and cities
        /// </summary>
        /// <returns></returns>
        private async Task CheckCountriesAndCitiesAsync()
        {
            if (!_context.Countries.Any())
            {
                var cities = new List<City>();
                cities.Add(new City { Name = "Lisbon" });
                cities.Add(new City { Name = "Oporto" });
                _context.Countries.Add(new Country
                {
                    Cities = cities,
                    Name = "Portugal"
                });

                var Scities = new List<City>();
                Scities.Add(new City { Name = "Barcelona" });
                Scities.Add(new City { Name = "Madrid" });
                _context.Countries.Add(new Country
                {
                    Cities = Scities,
                    Name = "Spain"
                });

                var Fcities = new List<City>();
                Fcities.Add(new City { Name = "Paris" });
                Fcities.Add(new City { Name = "Biarritz" });
                _context.Countries.Add(new Country
                {
                    Cities = Fcities,
                    Name = "France"
                });
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <returns></returns>
        private async Task CheckUsersAsync()
        {
            var user = await _userHelper.GetUserByEmailAsync("correiandreiamr@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    Name = "Andreia Correia",
                    Email = "correiandreiamr@gmail.com",
                    UserName = "correiandreiamr@gmail.com",
                    VAT = 123456789,
                    //Address = "Rua de Macau",
                    //CityId = _context.Countries.FirstOrDefault()
                    //.Cities.FirstOrDefault().Id,
                    //City = _context.Countries.FirstOrDefault()
                    //.Cities.FirstOrDefault()
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

        /// <summary>
        /// Check products
        /// </summary>
        /// <returns></returns>
        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                var user = _context.Users.FirstOrDefault();
                this.AddProduct("Sofa model 1", user);
                //this.AddProduct("Repolho", user);
                //this.AddProduct("Cenoura", user);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Add products
        /// </summary>
        /// <param name="name"></param>
        /// <param name="user"></param>
        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product
            {
                CreatedDate = DateTime.Now.AddDays(-2),
                UpdatedDate = DateTime.Now.AddDays(0),
                ImageUrl = ("~/images/Products/sofa6.png"),
                Name = name,
                Price = _random.Next(100),
                LastPurchase = DateTime.Now.AddDays(-1),
                LastSale = DateTime.Now.AddDays(0),
                IsAvailable = false,
                Stock = _random.Next(1000),
                User = user,
                CreatedBy = _context.Users.FirstOrDefault()
            });
        }
    }
}
