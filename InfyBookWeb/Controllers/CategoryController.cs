using InfyBookWeb.Data;
using InfyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        public IActionResult Create(Category obj)
        {
            return View();
        }
    }
}
