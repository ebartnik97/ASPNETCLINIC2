using ASPNETCLINIC.Data;
using ASPNETCLINIC.Helpers;
using ASPNETCLINIC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETCLINIC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDAL _idal;


        public HomeController(ILogger<HomeController> logger, IDAL idal)
        {
            _logger = logger;
            _idal = idal;
        }
         [Authorize]
        public IActionResult Index()
        {
            ViewData["Resources"]= JSONListHelper.GetResourceListJSONString(_idal.GetPatients());
            ViewData["Events"]= JSONListHelper.GetEventListJSONString(_idal.GetEvents());
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
    }
}
