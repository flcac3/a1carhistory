using Microsoft.AspNetCore.Mvc;

namespace userinfo.Controllers
{
    public class ServiceLogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
