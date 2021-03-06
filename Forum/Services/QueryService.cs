﻿using System;
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

        public IEnumerable<Comment> GetUserCommentsWithLength(int userId, int length)
        {
            var commentsWithLength = users.FirstOrDefault(x => x.Id == userId)?
                .Posts.SelectMany(x => x.Comments.Where(y => y.Body.Length > length));

            return commentsWithLength;
        }

        public IEnumerable<Tuple<int, string>> GetListOfCompleteTodos(int userId)
        {
            var listOfTodos = users.FirstOrDefault(x => x.Id == userId)?
                .Todos.Where(x => x.IsComplete).Select(x => Tuple.Create(x.Id, x.Name));

            return listOfTodos;
        }

        public IEnumerable<User> GetListOfSortedUsers()
        {
            var listOfSortedUsers = users.OrderBy(x => x.Name)
                .Select(x => new User(x, x.Todos.OrderByDescending(y => y.Name.Length)));

            return listOfSortedUsers;
        }

        public Tuple<User, Post, int?, int, Post, Post> GetUserStructureById(int userId)
        {
            var userStructure = (from user in users
                    where user.Id == userId
                    select Tuple.Create(user,
                        user.Posts.OrderBy(x => x.Title).LastOrDefault(),
                        user.Posts.OrderBy(x => x.Title).LastOrDefault()?.Comments.Count,
                        user.Todos.Count(x => !x.IsComplete),
                        user.Posts.OrderByDescending(x => x.Comments.Count(y => y.Body.Length > 80)).FirstOrDefault(),
                        user.Posts.OrderByDescending(x => x.Likes).FirstOrDefault()))
                .FirstOrDefault();

            return userStructure;
        }

        public Tuple<Post, Comment, Comment, int> GetPostStructureById(int postId)
        {
            var postStructure = (from user in users
                from post in user.Posts
                where post.Id == postId
                select Tuple.Create(post,
                    post.Comments.OrderByDescending(x => x.Body.Length).FirstOrDefault(),
                    post.Comments.OrderByDescending(x => x.Likes).FirstOrDefault(),
                    post.Comments.Count(x => x.Likes == 0 || x.Body.Length < 80))).FirstOrDefault();

            return postStructure;
        }

        public List<User> GetAllUsers()
        {
            return new List<User>(users);
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