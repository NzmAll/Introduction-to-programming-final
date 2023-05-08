using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Contants;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;
using TaskManagement.Services;

namespace TaskManagement.Client.Commands
{
    public class AddBlogCommand : ICommandHandler
    {
        public void Handle()
        {
            BlogRepository blogRepository = new BlogRepository();

            string title = Console.ReadLine();
            string content = Console.ReadLine();

            Blog blog = new Blog(title, content, UserService.CurrentUser, BlogStatus.Created);
            blogRepository.Insert(blog);
        }
    }
}
