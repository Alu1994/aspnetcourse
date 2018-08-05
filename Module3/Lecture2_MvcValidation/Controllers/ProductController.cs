using Lecture2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture2.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Save(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Product produto){
            if(!ModelState.IsValid){
                ViewBag.Validacao += "Produto Inválido para o Cadastro!";
            }

            return View();
        }
    }
}