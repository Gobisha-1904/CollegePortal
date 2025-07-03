// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

namespace CollegeERPPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       

    }
}
