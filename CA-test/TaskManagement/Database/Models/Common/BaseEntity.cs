using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Database.Models.Common
{
    public abstract class BaseEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }

    public class Comment
    {
        public string Text { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public object CreatedAt { get; internal set; }
        public object Author { get; internal set; }
    }
}
