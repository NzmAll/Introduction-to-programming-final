using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Database;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;

namespace TaskManagement.Admin.ShowUser
{
    public class ShowUserByIdCommand : ICommandHandler
    {
        public void Handle()
        {
            UserRepository userRepository = new UserRepository();

            while (true)
            {
                try
                {
                    int id = int.Parse(Console.ReadLine()!);

                    User user = userRepository.GetById(id);
                    if (user == null)
                    {
                        Console.WriteLine("Email not found");
                        continue;
                    }

                    Console.WriteLine(user.GetShortInfo());
                }
                catch
                {
                    Console.WriteLine("Invalid input pls try again");
                }
            }

        }
    }
}
