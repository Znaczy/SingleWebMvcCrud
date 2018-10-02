using Microsoft.AspNetCore.Mvc;
using SingleWebMvcCrud.Services;

namespace SingleWebMvcCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodosData _todos;

        public HomeController(ITodosData todos)
        {
            _todos = todos;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}