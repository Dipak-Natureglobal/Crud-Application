using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Todolist.Data;
using Todolist.Models;

namespace Todolist.Controllers
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
        //GET ACTION METHOD

        public IActionResult Create()

        {

            return View();

        }
        //post accetion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot match with the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category created sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int? id)

        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
           // var categoryFromDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);
           
            if(categoryFromDb==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }
        //post accetion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot match with the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category updated sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        public IActionResult Delete(int? id)

        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            // var categoryFromDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);
           
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);

        }
        //post accetion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);
            if(obj==null)
            {
                return NotFound(id);
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["Success"] = "Category deleted sucessfully";
            return RedirectToAction("Index");
            
         


        }
    }
}