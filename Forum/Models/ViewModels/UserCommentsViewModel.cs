using System.Collections.Generic;

namespace Forum.Models.ViewModels
{
    public class UserCommentsViewModel
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}