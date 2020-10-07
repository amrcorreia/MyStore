using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyStore.Web.Data.Repositories;
using MyStore.Web.Helpers;
using MyStore.Web.Models;

namespace ShopCET46.Web.Controllers
{
    
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMailHelper _mailHelper;

        public OrdersController(IOrderRepository orderRepository,
            IProductRepository productRepository,
            IMailHelper mailHelper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mailHelper = mailHelper;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _orderRepository.GetOrdersAsync(this.User.Identity.Name);
            return View(model);
        }

        public IActionResult Checkout()
        {
            
            
            
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var model = await _orderRepository.GetDetailTempsAsync(this.User.Identity.Name);
            if ((this.User.Identity.Name) == null)
            {
                return this.RedirectToAction("Login", "Account");
            }
            
            return View(model);
        }

        public async Task<IActionResult> Card(int id)
        {
            var model = await _orderRepository.GetByIdAsync(id);
            return View(model);
        }


        public IActionResult AddProduct()
        {
            var model = new AddItemViewModel
            {
                Quantity = 1,
                Products = _productRepository.GetComboProducts()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddItemViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await _orderRepository.AddItemToOrdemAsync(model, this.User.Identity.Name);
                return this.RedirectToAction("Create");
            }

            return this.View(model);
        }

        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _orderRepository.DeleteDetailTempAsync(id.Value);
            return this.RedirectToAction("Create");
        }


        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _orderRepository.DeleteOrderAsync(id.Value);
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Increase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _orderRepository.ModifyDetailTempQuantityAsync(id.Value, 1);
            return this.RedirectToAction("Create");
        }

        public async Task<IActionResult> Decrease(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _orderRepository.ModifyDetailTempQuantityAsync(id.Value, -1);
            return this.RedirectToAction("Create");
        }

        public async Task<IActionResult> ConfirmOrder()
        {
            var createdOrder = await _orderRepository.ConfirmOrderAsync(User.Identity.Name);

            if (createdOrder != null)
            {
                try
                {
                    EmailPDF generator = new EmailPDF();

                    var pdfByteArray = generator.PdfGenerate(createdOrder, User.Identity.Name);

                    _mailHelper.SendEmailPlusAttachment(User.Identity.Name, "Order - Plants Store",
                    "Thank you for choosing us.\n Please, check your email box! \n The purchase order follows attached", pdfByteArray);

                    ViewBag.Message = "Thank you for choosing us!\n\n\nPlease check your email box.";

                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return RedirectToAction("Create");
        }

        [Authorize]
        public async Task<IActionResult> Deliver(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderRepository.GetOrderAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            var model = new DeliverViewModel
            {
                Id = order.Id,
                DeliveryDate = DateTime.Today
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Deliver(DeliverViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.DeliverOrderAsync(model);
                return this.RedirectToAction("Index");
            }
                        
            return View();
        }
    }
}

