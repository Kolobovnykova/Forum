using Forum.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forum.Services
{
    public static class RequestService
    {
        private static readonly HttpClient client =
            new HttpClient {BaseAddress = new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/")};

        private static QueryService queryService;

        public static void InitializeData()
        {
            var dataFromServer = GetDataFromServer().GetAwaiter().GetResult();
            var users = GetCollection(dataFromServer);
            queryService = new QueryService(users);
        }

        private static async
            Task<(List<User> usersData, List<Post> postsData, List<Comment> commentsData, List<Todo> todosData)>
            GetDataFromServer()
        {
            string responseBody = await client.GetStringAsync("users");
            var usersData = JsonConvert.DeserializeObject<List<User>>(responseBody);

            responseBody = await client.GetStringAsync("posts");
            var postsData = JsonConvert.DeserializeObject<List<Post>>(responseBody);

            responseBody = await client.GetStringAsync("comments");
            var commentsData = JsonConvert.DeserializeObject<List<Comment>>(responseBody);

            responseBody = await client.GetStringAsync("todos");
            var todosData = JsonConvert.DeserializeObject<List<Todo>>(responseBody);
            return (usersData, postsData, commentsData, todosData);
        }

        private static IEnumerable<User> GetCollection(
            (List<User> usersData, List<Post> postsData, List<Comment> commentsData, List<Todo> todosData)
                dataFromServer)
        {
            var users = from user in dataFromServer.usersData
                join post in (from p in dataFromServer.postsData
                    join comment in dataFromServer.commentsData on p.Id equals comment.PostId into postComment
                    select new Post(p, postComment)) on user.Id equals post.UserId into postComments
                join todo in dataFromServer.todosData on user.Id equals todo.UserId into todos
                select new User(user, postComments, todos);

            return users;
        }
    }
}