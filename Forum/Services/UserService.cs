using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Models;

namespace Forum.Services
{
    public class UserService
    {
        private static List<User> users;
        private QueryService queryService;

        public UserService()
        {
            queryService = new QueryService();
            if (users == null)
            {
                users = queryService.GetAllUsers();
            }
        }

        public List<User> GetAll()
        {
            return users;
        }

        public void AddUser(User model)
        {
            model.CreatedAt = DateTime.Now;
            users.Add(model);
        }

        public void DeleteById(int id)
        {
            users.Remove(users.FirstOrDefault(x => x.Id == id));
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
    }
}
