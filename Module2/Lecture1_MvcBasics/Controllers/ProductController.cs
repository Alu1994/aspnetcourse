using Microsoft.AspNetCore.Mvc;

namespace Lecture1.Controllers
{
    //Transformacao em WebAPI
    [Route("api/product")]
    public class ProductController : Controller
    {
        [HttpGet("{id:int}")]
        public int Get(int id) {
            var x = HttpContext.Request.Path;
            return id;
        }

        [HttpGet]
        public IActionResult Get() {
            HttpContext.Response.StatusCode = 200;
            HttpContext.Response.Headers.Add("Matheus", "Eu que mando!");
            //return Content("teste", "application/doc");
            return File("asp-180719003545.pdf", "application/pdf");
            //return File("images/banner1.svg", "image/svg+xml");
        }
    }
}