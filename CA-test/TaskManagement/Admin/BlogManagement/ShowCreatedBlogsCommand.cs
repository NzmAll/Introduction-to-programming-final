using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Contants;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;

namespace TaskManagement.Admin.BlogManagement
{
    public class ShowCreatedBlogsCommand : ICommandHandler
    {
        public void Handle()
        {
            BlogRepository blogRepository = new BlogRepository();

            List<Blog> createdBlogs = blogRepository.GetAll(b => b.Status == BlogStatus.Created);

            foreach (Blog blog in createdBlogs)
            {
                Console.WriteLine($"{blog.Id} {blog.Title} {blog.Owner.GetFullName()} {blog.CreatedAt}");
            }
        }
    }
}
