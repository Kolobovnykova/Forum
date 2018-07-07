using Forum.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class PostController : Controller
    {
        private PostService postService;

        public PostController()
        {
            postService = new PostService();
        }
        
        [HttpGet]
        // GET: /Post/Index
        public IActionResult Index()
        {
            var items = postService.GetAll();
            return View(items);
        }

        [HttpGet]
        // GET: /Post/Details/1
        public IActionResult Details(int id)
        {
            var item = postService.GetById(id);
            return View(item);
        }
    }
}