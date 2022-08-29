using InfyBook.Models;
using InfyBook.Data;
using Microsoft.AspNetCore.Mvc;
using InfyBook.DataAccess.Repository.IRepository;

namespace InfyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;
        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll();
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {

                _db.Add(obj);
                _db.Save();
                TempData["success"] = "category created succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var catgeoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _db.GetFirstOrDefault(u => u.Id==id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {

                _db.Update(obj);
                _db.Save();
                TempData["success"] = "category updated succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catgeoryFromDbFirst = _db.GetFirstOrDefault(u=>u.Id==id);
            if (catgeoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(catgeoryFromDbFirst);
        }
        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Remove(obj);
            _db.Save();
            TempData["success"] = "category deleted succesfully";
            return RedirectToAction("Index");


        }
    }
}
