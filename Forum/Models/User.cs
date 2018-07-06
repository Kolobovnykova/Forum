using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
       // [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public string Email { get; set; }
        //public List<PostDTO> Posts { get; set; }
        //public List<TodoDTO> Todos { get; set; }
        //public List<CommentDTO> Comments { get; set; }
    }
}
