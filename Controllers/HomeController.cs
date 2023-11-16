using Microsoft.AspNetCore.Mvc;

namespace Generic_Employee_Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUsers()
        {
            return View();  
        }


        public IActionResult AddUsers(UserModel user)
        {
            return View();
        }
    }
}
