using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Database.Models.Common;
using TaskManagement.Database.Models;

namespace TaskManagement.Common.Commands
{
    public class CommentCommand
    {
        private List<Blog> blogs;

        public CommentCommand(List<Blog> blogs)
        {
            this.blogs = blogs;
        }

        public void AddComment()
        {
            Console.WriteLine("Enter the blog code:");
            string blogCode = Console.ReadLine()!;

            Blog blog = blogs.FirstOrDefault(b => b.Code == blogCode);

            if (blog == null)
            {
                Console.WriteLine("Blog with the specified code does not exist.");
                return;
            }

            Console.WriteLine("Enter the comment text:");
            string commentText = Console.ReadLine()!;

            Comment comment = new Comment
            {
                Text = commentText,
                FirstName = "Nizami",
                LastName = "Allahverdiyev"
            };


            blog.Comments.Add(comment);

            Console.WriteLine($"Comment added to the blog with code {blogCode}.");
        }
    }
}
