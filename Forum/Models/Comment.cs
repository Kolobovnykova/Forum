using System;

namespace Forum.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int Likes { get; set; }

        public Comment() {}

        public Comment(Comment comment)
        {
            Id = comment.Id;
            CreatedAt = comment.CreatedAt;
            Body = comment.Body;
            Likes = comment.Likes;
            PostId = comment.PostId;
            UserId = comment.UserId;
        }
    }
}