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

namespace TaskManagement.Admin.DePromoteFromAdmin
{
    public class DePromoteFromAdminCommand : ICommandHandler
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

            //if (email == UserService.CurrentUser.Email) 
            //{
            //    Console.WriteLine("You can't yourself");
            //    return;
            //}

            if (user == UserService.CurrentUser)
            {
                Console.WriteLine("You can't yourself");
                return;
            }

            if (user.Role == UserRole.Member)
            {
                Console.WriteLine("User is already standart");
                return;
            }

            user.Role = UserRole.Member;

            Console.WriteLine("Admin succussfully depromoted from admin to user!");
        }
    }
}
