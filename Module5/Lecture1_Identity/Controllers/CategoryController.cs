using System.Linq;
using Lecture1_Identity.Data;
using Lecture1_Identity.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Lecture1_Identity.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index(int? id){
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            Category categoriaSelecionada = null;
            if(id > 0){
                categoriaSelecionada = categories.FirstOrDefault(filter => filter.Id.Equals(id));
            }
            return View(categoriaSelecionada);
        }

        [HttpPost]
        public IActionResult Register([FromQuery]Category category){
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }            

            if(category?.Id > 0){
                var categorySaved = _context.Categories.FirstOrDefault(filter => filter.Id.Equals(category.Id));
                if(categorySaved == null){
                    return RedirectToAction("Index");
                }
                categorySaved.Name = category.Name;
                _context.Categories.Update(categorySaved);
            }else{
                _context.Categories.Add(category);
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(int id){
            var categoryRemoved = _context.Categories.FirstOrDefault(filter => filter.Id.Equals(id));
            _context.Categories.Remove(categoryRemoved);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}