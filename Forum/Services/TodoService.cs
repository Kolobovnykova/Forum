using System.Collections.Generic;
using System.Linq;
using Forum.Models;

namespace Forum.Services
{
    public class TodoService
    {
        private static List<Todo> todos;
        private QueryService queryService;

        public TodoService()
        {
            queryService = new QueryService();
            if (todos == null)
            {
                todos = queryService.GetAllTodos();
            }
        }
        
        public List<Todo> GetAll()
        {
            return todos;
        }
        
        public Todo GetById(int id)
        {
            return todos.FirstOrDefault(x => x.Id == id);
        }
    }
}