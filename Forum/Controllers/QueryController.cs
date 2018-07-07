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

        //// Post: /Query/GetUserCommentsNumber
        //public IActionResult GetUserCommentsNumber(int id)
        //{
        //    return View(id);
        //}
    }
}