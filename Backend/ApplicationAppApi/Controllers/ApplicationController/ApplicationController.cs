using Microsoft.AspNetCore.Mvc;

namespace ApplicationAppApi.Controllers.ApplicationController
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
