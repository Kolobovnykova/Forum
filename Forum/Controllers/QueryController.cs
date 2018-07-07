using Forum.Models.ViewModels;
using Forum.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class QueryController : Controller
    {
        private QueryService queryService;

        public QueryController()
        {
            queryService = new QueryService();
        }

        // GET: /Query/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Query/GetUserCommentsNumber
        public IActionResult GetUserCommentsNumber()
        {
            return View();
        }

        // Post: /Query/GetUserCommentsNumber
        [HttpPost]
        public IActionResult GetUserCommentsNumber(int id)
        {
            var viewModel = new PostCommentNumberViewModel();
            if (ModelState.IsValid)
            {
                viewModel.Model = queryService.GetUserCommentsNumber(id);

                return View(viewModel);
            }

            return View(viewModel);
        }
    }
}