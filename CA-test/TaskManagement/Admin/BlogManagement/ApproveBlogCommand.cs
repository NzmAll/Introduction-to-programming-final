using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Contants;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;
using TaskManagement.Services;

namespace TaskManagement.Admin.BlogManagement
{
    public class ApproveBlogCommand : BaseBlogModeration, ICommandHandler
    {
        private MessageService _messageService;

        public ApproveBlogCommand(BlogRepository blogRepository, MessageService messageService)
            : base(blogRepository)
        {
            _messageService = messageService;
        }

        public void Handle()
        {
            Blog blog = ValidateAndGetBlog();
            if (blog is null) return;

            blog.Status = BlogStatus.Approved;

            _messageService.SenApprovedMessage(blog);
        }
    }
}
