using System.Collections.Generic;
using System.Linq;
using Forum.Models;

namespace Forum.Services
{
    public class PostService
    {
        private static List<Post> posts;
        private QueryService queryService;

        public PostService()
        {
            queryService = new QueryService();
            if (posts == null)
            {
                posts = queryService.GetAllPosts();
            }
        }

        public List<Post> GetAll()
        {
            return posts;
        }

        public Post GetById(int id)
        {
            return posts.FirstOrDefault(x => x.Id == id);
        }
    }
}