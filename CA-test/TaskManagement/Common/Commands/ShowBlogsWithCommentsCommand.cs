using System;
using System.Linq;
using System.Windows.Input;
using TaskManagement.Contants;
using TaskManagement.Database;
using TaskManagement.Database.Models;
using TaskManagement.Database.Models.Common;

namespace TaskManagement.Common.Commands
{
    public class ShowBlogsWithCommentsCommand : ICommand
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IDbContext _dbContext;

        public ShowBlogsWithCommentsCommand(IAuthenticationService authenticationService, IDbContext dbContext)
        {
            _authenticationService = authenticationService;
            _dbContext = dbContext;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            User user = _authenticationService.GetAuthenticatedUser();
            if (user == null)
            {
                Console.WriteLine("You need to log in to use this command.");
                return;
            }

            IQueryable<Blog> blogs = _dbContext.Blogs.Where(b => b.Owner.Id == user.Id && b.Status == BlogStatus.Approved).OrderByDescending(b => b.CreatedAt);

            foreach (Blog blog in blogs)
            {
                Console.WriteLine($"[{blog.CreatedAt:dd.MM.yyyy}] [{blog.Code}] [{blog.Owner.FirstName} {blog.Owner.LastName}]");
                Console.WriteLine($"=== {blog.Title} ===");
                Console.WriteLine(blog.Content);

                Console.WriteLine("Comments:");
                int i = 1;
                foreach (Comment comment in blog.Comments)
                {
                    Console.WriteLine($"{i++}. [{comment.CreatedAt:dd.MM.yyyy}] [{comment.FirstName} {comment.LastName}] - {comment.Text}");
                }
            }
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
