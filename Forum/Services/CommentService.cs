using System.Collections.Generic;
using System.Linq;
using Forum.Models;

namespace Forum.Services
{
    public class CommentService
    {
        private static List<Comment> comments;
        private QueryService queryService;

        public CommentService()
        {
            queryService = new QueryService();
            if (comments == null)
            {
                comments = queryService.GetAllComments();
            }
        }
        
        public List<Comment> GetAll()
        {
            return comments;
        }
        
        public Comment GetById(int id)
        {
            return comments.FirstOrDefault(x => x.Id == id);
        }
    }
}