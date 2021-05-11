using System;
using System.Data;
using System.Linq;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly DutchContext _context;

        public AppController(IMailService mailService, DutchContext context)
        {
            _mailService = mailService;
            _context = context;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            // throw new InvalidProgramException("Bad things happens to good developers");
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("slawgra4@gmail.com", model.Subject,
                    $"From: {model.Name} {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            return View();
        }
        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }
        [HttpGet("shop")]
        public IActionResult Shop()
        {
            var results = _context.Products.OrderBy(p => p.Category);
            
            return View(results);
        }
    }
}