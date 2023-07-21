using JwtMVCExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JwtMVCExample.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}