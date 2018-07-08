using System;

namespace Forum.Models.ViewModels
{
    public class PostStructureViewModel
    {
        public int Id { get; set; }
        public Tuple<Post, Comment, Comment, int> Model { get; set; }
    }
}