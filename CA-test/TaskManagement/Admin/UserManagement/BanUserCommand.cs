using TaskManagement.Common.Commands;
using TaskManagement.Contants;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;

namespace TaskManagement.Admin.UserManagement
{
    public class BanUserCommand : ICommandHandler
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
                Console.WriteLine($"User is admin you can't ban him {user.GetShortInfo()}");
                return;
            }

            user.IsBanned = true;
        }
    }
}
