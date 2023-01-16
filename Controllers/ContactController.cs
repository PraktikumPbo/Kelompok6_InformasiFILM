using Microsoft.AspNetCore.Mvc;

namespace ASPFILM.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
