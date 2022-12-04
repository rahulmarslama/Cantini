using Cantini.Database.Model;
using Cantini.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Cantini.Controllers
{
    public class FoodItemController : Controller
    {

        private readonly FoodItemRepo _repo;


        public FoodItemController(FoodItemRepo repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {

            IEnumerable<FoodItem> item = _repo.GetFoodItem();
            return View(item);
        }

        //Below Create Action method for a form to add new food-item ,basically doing GET
        public IActionResult Create()
        {
            return View();
        }

        //Below Create Action Method to add food-item to the database,basically doing POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FoodItem obj)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Below Edit Action method for a form to edit food-item ,basically doing GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }

            var item = _repo.GetById(id);
            if(item==null)
            {
                return NotFound();
            }
            return View(item);
        }

        //Below Edit Action Method to edit existing food-item to the database,basically doing POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FoodItem item)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

       
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var item = _repo.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

       
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(FoodItem obj)
        {
            
                _repo.Delete(obj);


            return RedirectToAction("Index");
        }


    }
}
