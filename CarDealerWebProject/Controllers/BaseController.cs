using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerWebProject.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
