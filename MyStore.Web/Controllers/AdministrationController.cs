using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyStore.Web.Data.Entities;
using MyStore.Web.Helpers;
using MyStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserHelper _userHelper;

        public AdministrationController(UserManager<User> userManager,
            IUserHelper userHelper)
        {
            _userManager = userManager;
            _userHelper = userHelper;
        }

        // GET: Users
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }

        

    }
}
