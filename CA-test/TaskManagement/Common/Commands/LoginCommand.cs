using TaskManagement.Admin;
using TaskManagement.Client;
using TaskManagement.Contants;
using TaskManagement.Database;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;
using TaskManagement.Exceptions;
using TaskManagement.Services;

namespace TaskManagement.Common.Commands
{
    public class LoginCommand : ICommandHandler
    {
        public void Handle() //use alias
        {
            string email = Console.ReadLine()!;
            string password = Console.ReadLine()!;
            UserRepository userRepository = new UserRepository();
            List<User> users = userRepository.GetAll().Cast<User>().ToList();

            for (int i = 0; i < users.Count; i++)
            {
                User user = users[i];

                if (user.Email == email && user.Password == password)
                {
                    if (user.IsBanned)
                    {
                        try
                        {
                            Console.WriteLine(LocalizationService.GetTranslation(TranslationKey.AccountBlocked));
                            return;
                        }
                        catch (LocalizationException)
                        {

                            throw;
                        }

                    }

                    UserService.CurrentUser = user;

                    if (user.Role == UserRole.Admin)
                    {
                        AdminDashboard adminDashboard = new AdminDashboard();
                        adminDashboard.Introduction();
                    }
                    else
                    {
                        ClientDashboard clientDashboard = new ClientDashboard();
                        clientDashboard.Introduction();
                    }
                }
            }
        }
    }
}
