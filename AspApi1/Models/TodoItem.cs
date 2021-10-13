using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListServerApp.Models
{
    public class TodoItem
    {
        [Key]
        public long TodoId { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

    }
}
