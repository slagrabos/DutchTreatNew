using System;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
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
            return View();
        }
        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}