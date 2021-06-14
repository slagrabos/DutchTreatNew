using System;
using System.Data;
using System.Linq;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IDutchRepository _repository;

        public AppController(IMailService mailService, IDutchRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }
        [HttpGet("/")]
        public IActionResult Index()
        {
            var results = _repository.GetAllProducts();
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
        [Authorize]
        [HttpGet("shop")]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            
            return View(results);
        }
    }
}