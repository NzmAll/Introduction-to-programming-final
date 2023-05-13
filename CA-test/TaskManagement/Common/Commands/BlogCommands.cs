using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Contants;
using TaskManagement.Database.Models;

namespace TaskManagement.Common.Commands
{
    public static class BlogCommands
    {
        public static void ShowBlogsWithComments(User user, List<Blog> blogs)
        {
            if (user == null)
            {
                Console.WriteLine("You need to be logged in to use this command.");
                return;
            }

            var approvedBlogs = blogs.Where(b => b.Status == BlogStatus.Approved);

            foreach (var blog in approvedBlogs)
            {
                Console.WriteLine($"[{blog.PublishedAt:dd.MM.yyyy}] [{blog.Code}] [{blog.Owner.FirstName} {blog.Owner.LastName}]");
                Console.WriteLine($"=== {blog.Title} ===");
                Console.WriteLine(blog.Content);
                Console.WriteLine("\nComments :");

                if (blog.Comments.Count == 0)
                {
                    Console.WriteLine("No comments yet.");
                }
                else
                {
                    int rowNumber = 1;
                    foreach (var comment in blog.Comments)
                    {
                        //Console.WriteLine($"{rowNumber}. [{comment.CreatedAt:dd.MM.yyyy}] [{comment.Author.FirstName} {comment.Author.LastName}] - {comment.Text}");
                        rowNumber++;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
