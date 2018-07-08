using System;
using System.Collections.Generic;

namespace Forum.Models.ViewModels
{
    public class ListOfCompleteTodosViewModel
    {
        public int Id { get; set; }
        public IEnumerable<Tuple<int, string>> Model { get; set; }
    }
}