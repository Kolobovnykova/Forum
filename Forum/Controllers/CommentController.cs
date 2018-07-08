using Forum.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class CommentController : Controller
    {
        private CommentService commentService;

        public CommentController()
        {
            commentService = new CommentService();
        }
        
        [HttpGet]
        // GET: /Comment/Index
        public IActionResult Index()
        {
            var items = commentService.GetAll();
            return View(items);
        }

        [HttpGet]
        // GET: /Comment/Details/1
        public IActionResult Details(int id)
        {
            var item = commentService.GetById(id);
            return View(item);
        }
    }
}