using Microsoft.AspNetCore.Mvc;

namespace ShoesMarket.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
