
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Contants;
using TaskManagement.Database.Models.Common;


namespace TaskManagement.Database.Models
{
    public class Blog : BaseEntity<decimal>
    {
        private User currentUser;
        private BlogStatus created;

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
            Console.WriteLine($"Comment added to the blog with code {Code}.");
        }

        public static int IdCounter { get; private set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public User Owner { get; set; }
        
        public BlogStatus Status { get; set; }

        public string Code { get; set; }

        public List<Comment> Comments { get; set; }
        public object PublishedAt { get; internal set; }

        public Blog(string title, string content, User owner, BlogStatus status, string code)
        {
            Id = ++IdCounter;
            Title = title;
            Content = content;
            Owner = owner;
            CreatedAt = DateTime.Now;
            Status = status;
            Code = code;
            Comments = new List<Comment>();
        }

        public Blog(string title, string content, User currentUser, BlogStatus created)
        {
            Title = title;
            Content = content;
            this.currentUser = currentUser;
            this.created = created;
        }

        private string GenerateUniqueCode()
        {
            Random random = new Random();
            string code = "BL" + random.Next(10000, 99999).ToString();
            return code;
        }


    }

    internal class Blogs<T>
    {
        public static implicit operator Blogs<T>(List<Blog> v)
        {
            throw new NotImplementedException();
        }
    }
}
