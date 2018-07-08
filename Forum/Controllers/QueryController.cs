using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Forum.Models;
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
        
        // GET: /Query/GetUserCommentsWithLength
        public IActionResult GetUserCommentsWithLength()
        {
            return View();
        }

        // Post: /Query/GetUserCommentsWithLength
        [HttpPost]
        public IActionResult GetUserCommentsWithLength(int id, int length)
        {
            var viewModel = new UserCommentsViewModel();
            if (ModelState.IsValid)
            {
                viewModel.Comments = queryService.GetUserCommentsWithLength(id, length);

                return View(viewModel);
            }

            return View(viewModel);
        }   
        
        // GET: /Query/GetListOfCompleteTodos
        public IActionResult GetListOfCompleteTodos()
        {
            return View();
        }

        // Post: /Query/GetListOfCompleteTodos
        [HttpPost]
        public IActionResult GetListOfCompleteTodos(int id)
        {
            var viewModel = new ListOfCompleteTodosViewModel();
            if (ModelState.IsValid)
            {
                viewModel.Model = queryService.GetListOfCompleteTodos(id);

                return View(viewModel);
            }

            return View(viewModel);
        }

        // GET: /Query/GetListOfSortedUsers
        public IActionResult GetListOfSortedUsers()
        {
            var model = new List<User>();
            model = queryService.GetListOfSortedUsers().ToList();
            return View(model);
        }
    }
}