using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contants;
using TaskManagement.Database.Models.Common;

namespace TaskManagement.Database.Models
{
    public class Blog : BaseEntity<decimal>
    {
        public static int IdCounter { get; private set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public User Owner { get; set; }
        
        public BlogStatus Status { get; set; }

        public Blog(string title, string content, User owner, BlogStatus status)
        {
            Id = ++IdCounter;
            Title = title;
            Content = content;
            Owner = owner;
            CreatedAt = DateTime.Now;
            Status = status;
        }
    }
}
