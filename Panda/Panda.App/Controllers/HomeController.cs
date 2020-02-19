using Microsoft.AspNetCore.Mvc;

namespace Panda.App.Controllers
{
    [Controller]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
