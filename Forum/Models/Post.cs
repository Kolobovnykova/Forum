using System;
using System.Collections.Generic;

namespace Forum.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int Likes { get; set; }

        public List<Comment> Comments { get; set; }

        public Post() {}

        public Post(Post post)
        {
            Id = post.Id;
            CreatedAt = post.CreatedAt;
            Body = post.Body;
            Likes = post.Likes;
            Title = post.Title;
            UserId = post.UserId;
        }

        public Post(Post post, IEnumerable<Comment> comments) : this(post)
        {
            Comments = new List<Comment>(comments);
        }
    }
}