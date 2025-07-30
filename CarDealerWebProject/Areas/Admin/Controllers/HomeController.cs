using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebProject.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
