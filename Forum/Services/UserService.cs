using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Models;

namespace Forum.Services
{
    public class UserService
    {
        private static List<User> users;

        public UserService()
        {
            if (users == null)
            {
                users = new List<User>
                {
                    new User {Avatar = "", CreatedAt = DateTime.Now, Email = "123", Id = 1, Name = "Name1"},
                    new User {Avatar = "", CreatedAt = DateTime.Now, Email = "123", Id = 2, Name = "Name2"},
                    new User {Avatar = "", CreatedAt = DateTime.Now, Email = "444", Id = 3, Name = "Name3"},
                    new User {Avatar = "", CreatedAt = DateTime.Now, Email = "532", Id = 4, Name = "Name4"},
                    new User {Avatar = "", CreatedAt = DateTime.Now, Email = "123", Id = 5, Name = "Name5"}
                };
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
