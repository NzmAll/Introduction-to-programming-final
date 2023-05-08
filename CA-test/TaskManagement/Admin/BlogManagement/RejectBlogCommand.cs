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

namespace TaskManagement.Admin.BlogManagement
{
    public class RejectBlogCommand : BaseBlogModeration, ICommandHandler
    {
        private MessageService _messageService;

        public RejectBlogCommand(BlogRepository blogRepository, MessageService messageService)
            : base(blogRepository)
        {
            _messageService = messageService;
        }

        public void Handle()
        {
            Blog blog = ValidateAndGetBlog();
            if (blog is null) return;

            blog.Status = BlogStatus.Rejected;

            _messageService.SendRejectedMessage(blog);
        }
    }
}
