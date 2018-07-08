using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public string Email { get; set; }

        public User() {}

        public User(User user, IEnumerable<Post> posts, IEnumerable<Todo> todos)
        {
            Id = user.Id;
            CreatedAt = user.CreatedAt;
            Name = user.Name;
            Email = user.Email;
            Avatar = user.Avatar;
            Posts = new List<Post>(posts);
            Todos = new List<Todo>(todos);
        }

        public User(User user, IEnumerable<Todo> todos)
        {
            Id = user.Id;
            CreatedAt = user.CreatedAt;
            Name = user.Name;
            Email = user.Email;
            Avatar = user.Avatar;
            Todos = new List<Todo>(todos);
        }

        public List<Post> Posts { get; set; }
        public List<Todo> Todos { get; set; }
        public List<Comment> Comments { get; set; }
    }
}