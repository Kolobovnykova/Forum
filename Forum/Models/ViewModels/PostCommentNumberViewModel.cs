using System;
using System.Collections.Generic;

namespace Forum.Models.ViewModels
{
    public class PostCommentNumberViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Tuple<Post, int>> Model { get; set; }
    }
}