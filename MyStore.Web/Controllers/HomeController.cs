using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Web.Data.Entities;
using MyStore.Web.Helpers;
using MyStore.Web.Models;

namespace MyStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailHelper _mailHelper;

        public HomeController(IMailHelper mailHelper)
        {
            _mailHelper = mailHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Contact(ContactForm model)
        {
            if (ModelState.IsValid)
            {


                _mailHelper.SendMail("correiandreiamr@gmail.com", "Contact Form - YourVet App", $"<h1>YourVet - Contact from the App</h1>" +
                           $"" +
                           $"<br/>" +
                           $"<p><strong>Contact Name:</strong> {model.Name}</p>" +
                           $"<p><strong>Email:</strong> {model.Email}</p>" +
                           $"<br/>" +
                           $"<p><strong>Subject:</strong> {model.Subject}</p>" +
                           $"<p><strong>Message:</strong> {model.Message}</p>" +
                           $"<br/>" +
                           $"_________________________________________________");

                _mailHelper.SendMail(model.Email, "Contact Form - YourVet App", $"<h1>YourVet - Email received successfully</h1>" +
                           $"<body>" +
                           $"<br/>" +
                           $"" +
                           $"<h4>Welcome to YourVet, we confirm that we have received your email successfully.</h4>" +
                           $"<br/>" +
                           $"<p><strong>Contact Name:</strong> {model.Name}</p>" +
                           $"<p><strong>Email:</strong> {model.Email}</p>" +
                           $"<br/>" +
                           $"<p><strong>Subject:</strong> {model.Subject}</p>" +
                           $"<p><strong>Message:</strong> {model.Message}</p>" +
                           $"<br/>" +
                           $"<p>We will contact you as soon as possible.</p><body>");

                return RedirectToAction("Index");
            }
            else
            {
                return Index();
            }
        }

        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
