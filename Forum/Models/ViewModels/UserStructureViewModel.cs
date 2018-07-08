using System;

namespace Forum.Models.ViewModels
{
    public class UserStructureViewModel
    {
        public int Id { get; set; }
        public Tuple<User, Post, int?, int, Post, Post> Model { get; set; }
    }
}