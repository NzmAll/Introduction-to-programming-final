using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Contants;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;

namespace TaskManagement.Admin.DePromoteFromAdmin
{
    public class PromoteToAdminCommand : ICommandHandler
    {
        public void Handle()
        {
            UserRepository userRepository = new UserRepository();

            string email = Console.ReadLine()!;
            User user = userRepository.GetUserOrDefaultByEmail(email);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            if (user.Role == UserRole.Admin)
            {
                Console.WriteLine("User is already is admin");
                return;
            }

            user.Role = UserRole.Admin;

            Console.WriteLine("User succussfully promoted to admin!");
        }
    }
}
