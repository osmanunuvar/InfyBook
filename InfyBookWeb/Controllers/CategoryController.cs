using Microsoft.AspNetCore.Mvc;

namespace InfyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
