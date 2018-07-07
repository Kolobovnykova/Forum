using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Models;

namespace Forum.Services
{
    public class QueryService
    {
        private static IEnumerable<User> users;

        public QueryService()
        {
        }

        public QueryService(IEnumerable<User> usersData)
        {
            if (users == null)
            {
                users = new List<User>(usersData);
            }
        }

        public IEnumerable<Tuple<Post, int>> GetUserCommentsNumber(int userId)
        {
            var postWithComments = users.FirstOrDefault(x => x.Id == userId)?
                .Posts.Select(x => Tuple.Create(x, x.Comments.Count));

            return postWithComments;
        }

        //public void PrintUserCommentsNumber(IEnumerable<(Post post, int amount)> postsComments, int userId)
        //{
        //    Console.Clear();
        //    Console.WriteLine("Get number of comments under posts of a particular user.");
        //    if (postsComments == null)
        //    {
        //        Console.WriteLine($"User with id {userId} was not found.");
        //        return;
        //    }

        //    Console.WriteLine($"User Id: {userId}");
        //    foreach (var post in postsComments)
        //    {
        //        Console.WriteLine($"Post #{post.post.Id} has {post.amount} comment(s)");
        //    }
        //}

        public (IEnumerable<Comment> comments, int userId) GetUserCommentsWithLength(int userId)
        {
            var commentsWithLength = users.FirstOrDefault(x => x.Id == userId)?
                .Posts.SelectMany(x => x.Comments.Where(y => y.Body.Length > 50));

            return (commentsWithLength, userId);
        }

        public void PrintUserCommentsWithLength(IEnumerable<Comment> commentsWithLength, int userId)
        {
            Console.Clear();
            Console.WriteLine("Get number of comments with length more than 50 of a particular user.");
            if (commentsWithLength == null)
            {
                Console.WriteLine($"User with id {userId} was not found.");
                return;
            }

            Console.WriteLine($"User Id: {userId}");
            foreach (var comment in commentsWithLength)
            {
                Console.WriteLine(comment);
            }
        }

        public (IEnumerable<(int id, string name)> todos, int userId) GetListOfCompleteTodos(int userId)
        {
            var listOfTodos = users.FirstOrDefault(x => x.Id == userId)?
                .Todos.Where(x => x.IsComplete).Select(x => (x.Id, x.Name));

            return (listOfTodos, userId);
        }

        public void PrintListOfCompleteTodos(IEnumerable<(int id, string name)> todos, int userId)
        {
            Console.Clear();
            Console.WriteLine("Get number of complete todos of a particular user.");
            if (todos == null)
            {
                Console.WriteLine($"User with id {userId} was not found or there are no complete todos.");
                return;
            }

            Console.WriteLine($"User Id: {userId}");
            foreach (var todo in todos)
            {
                Console.WriteLine($"Todo #{todo.id} with name {todo.name} is complete");
            }
        }

        public IEnumerable<User> GetListOfSortedUsers(int numberOfUsers)
        {
            var listOfSortedUsers = users.OrderBy(x => x.Name)
                .Select(x => new User(x, x.Todos.OrderByDescending(y => y.Name.Length))).Take(numberOfUsers);

            return listOfSortedUsers;
        }

        public void PrintSortedUsersWithTodos(IEnumerable<User> users)
        {
            Console.Clear();
            Console.WriteLine("Get sorted list of users with sorted todos in descending order.");
            if (users == null)
            {
                Console.WriteLine("Users were not found.");
                return;
            }

            Console.WriteLine($"User Id: {users}");
            foreach (var user in users)
            {
                Console.WriteLine(user);
                foreach (var todo in user.Todos)
                {
                    Console.WriteLine($"\t{todo}");
                }
            }
        }

        public (User user, Post lastPost, int? commentsAmount, int incompleteTodosAmount, Post bestPostLength,
            Post bestPostLikes) GetUserStructureById(int userId)
        {
            var userStructure = (from user in users
                    where user.Id == userId
                    select (user,
                        user.Posts.OrderBy(x => x.Title).LastOrDefault(),
                        user.Posts.OrderBy(x => x.Title).LastOrDefault()?.Comments.Count,
                        user.Todos.Count(x => !x.IsComplete),
                        user.Posts.OrderByDescending(x => x.Comments.Count(y => y.Body.Length > 80)).FirstOrDefault(),
                        user.Posts.OrderByDescending(x => x.Likes).FirstOrDefault()))
                .FirstOrDefault();

            return userStructure;
        }

        public void PrintUserStructureById(
            (User user, Post lastPost, int? commentsAmount, int incompleteTodosAmount, Post bestPostLength,
                Post bestPostLikes) userStructure, int userId)
        {
            Console.Clear();
            Console.WriteLine("Get a structure of a user by id.");

            Console.WriteLine($"User id: \n{userId}");
            Console.WriteLine($"User: \n{userStructure.user}");
            Console.WriteLine($"Last post: \n{userStructure.lastPost}");
            Console.WriteLine($"Number of comments under last post: \n{userStructure.commentsAmount}");
            Console.WriteLine($"Number of incomplete todos: \n{userStructure.incompleteTodosAmount}");
            Console.WriteLine(
                $"Best post with most comments with length 80+ symbols: \n{userStructure.bestPostLength}");
            Console.WriteLine($"Best post with likes: \n{userStructure.bestPostLikes}");
        }

        public (Post post, Comment longestComment, Comment luckyComment, int unluckyComments)
            GetPostStructureById(int postId)
        {
            var postStructure = (from user in users
                from post in user.Posts
                where post.Id == postId
                select (post,
                    post.Comments.OrderByDescending(x => x.Body.Length).FirstOrDefault(),
                    post.Comments.OrderByDescending(x => x.Likes).FirstOrDefault(),
                    post.Comments.Count(x => x.Likes == 0 || x.Body.Length < 80))).FirstOrDefault();

            return postStructure;
        }

        public void PrintPostStructureById(
            (Post post, Comment longestComment, Comment luckyComment, int unluckyComments) postStructure,
            int postId)
        {
            Console.Clear();
            Console.WriteLine("Get a structure of a post by id.");

            Console.WriteLine($"Post id: \n{postId}");
            Console.WriteLine($"Post: \n{postStructure.post}");
            Console.WriteLine($"Longest comment: \n{postStructure.longestComment}");
            Console.WriteLine($"A comment with most likes: \n{postStructure.luckyComment}");
            Console.WriteLine($"Number of comments with 0 likes or <80 symbols: \n{postStructure.unluckyComments}");
        }

        public List<User> GetAllUsers()
        {
            return new List<User>(users);
        }
        
        public void PrintAllUsers()
        {
            foreach (var user in users)
            {
                Console.WriteLine(user);
                foreach (var post in user.Posts)
                {
                    Console.WriteLine($"\t{post}");
                    foreach (var comment in post.Comments)
                    {
                        Console.WriteLine($"\t\t{comment}");
                    }
                }

                foreach (var todo in user.Todos)
                {
                    Console.WriteLine($"\t{todo}");
                }
            }
        }

        public List<Post> GetAllPosts()
        {
            return users.SelectMany(x => x.Posts).OrderBy(x => x.Id).ToList();
        }
        
        public List<Comment> GetAllComments()
        {
            return users.SelectMany(x => x.Posts).SelectMany(x => x.Comments).OrderBy(x => x.Id).ToList();
        }
        
        public List<Todo> GetAllTodos()
        {
            return users.SelectMany(x => x.Todos).OrderBy(x => x.Id).ToList();
        }
    }
}