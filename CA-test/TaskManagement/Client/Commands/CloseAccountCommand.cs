using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Database.Repositories;
using TaskManagement.Services;

namespace TaskManagement.Client.Commands
{
    public class CloseAccountCommand : ICommandHandler
    {
        public void Handle()
        {
            UserRepository userRepository = new UserRepository();

            string password = Console.ReadLine()!;

            if (UserService.CurrentUser.Password != password)
            {
                Console.WriteLine("Invalid passowrd");
                return;
            }

            userRepository.Remove(UserService.CurrentUser);
        }
    }
}
