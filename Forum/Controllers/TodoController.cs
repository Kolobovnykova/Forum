using Forum.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class TodoController : Controller
    {
        private TodoService todoService;

        public TodoController()
        {
            todoService = new TodoService();
        }
        
        [HttpGet]
        // GET: /Todo/Index
        public IActionResult Index()
        {
            var items = todoService.GetAll();
            return View(items);
        }

        [HttpGet]
        // GET: /Todo/Details/1
        public IActionResult Details(int id)
        {
            var item = todoService.GetById(id);
            return View(item);
        }
    }
}