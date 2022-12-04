using Cantini.Database.Model;
using Cantini.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cantini.Controllers
{
    public class StudentController : Controller
    {
        
       private readonly StudentRepo _repo;


        public StudentController(StudentRepo repo)
        {
           _repo = repo;
        }


        public IActionResult Index()
        {

            List<Student> item = _repo.GetStudent();
            return View(item);
        }
        public IActionResult Create()
        {
            return View();
        }

        //Below Create Action Method to add food-item to the database,basically doing POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
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

        //Below Edit Action Method to edit existing food-item to the database,basically doing POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student item)
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


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Student obj)
        {

            _repo.Delete(obj);


            return RedirectToAction("Index");
        }
    }
}
