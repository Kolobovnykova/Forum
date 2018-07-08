using Forum.Models;
using Forum.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [HttpGet]
        // GET: /Users/Index
        public IActionResult Index()
        {
            var items = userService.GetAll();
            return View(items);
        }

        // GET: /Users/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Post: /Users/Create
        [HttpPost]
        public IActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                userService.AddUser(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = userService.GetById(id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            userService.DeleteById(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var item = userService.GetById(id);
            return View(item);
        }
    }
}