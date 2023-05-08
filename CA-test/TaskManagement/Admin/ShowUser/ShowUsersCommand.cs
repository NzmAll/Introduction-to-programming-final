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
    public class ShowUsersCommand : ICommandHandler
    {
        public void Handle()
        {
            UserRepository userRepository = new UserRepository();

            DateTime fromDate = DateTime.Parse(Console.ReadLine()!); // YY-DD-YYYYY 
            List<User> users = userRepository.GetAll(u => u.CreatedAt > fromDate);

            int order = 1;

            foreach (User user in users)
            {
                Console.WriteLine($"{order}. {user.GetShortInfo()} register date :  {user.CreatedAt.ToString("dd/MMMM/yyyy")}");
                order++;
            }
        }
    }
}
