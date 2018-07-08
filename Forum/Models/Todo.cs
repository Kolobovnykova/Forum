using System;

namespace Forum.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public int UserId { get; set; }

        public Todo() { }

        public Todo(Todo todo)
        {
            Id = todo.Id;
            CreatedAt = todo.CreatedAt;
            Name = todo.Name;
            IsComplete = todo.IsComplete;
            UserId = todo.UserId;
        }
    }
}