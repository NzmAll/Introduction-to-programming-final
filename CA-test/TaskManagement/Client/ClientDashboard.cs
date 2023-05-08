using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common;
using TaskManagement.Database.Models;
using TaskManagement.Services;

namespace TaskManagement.Client
{
    public class ClientDashboard : IDashboard
    {
        public void Introduction()
        {
            Console.WriteLine($"Hello! : {UserService.CurrentUser.Email} {UserService.CurrentUser.Name}");

        }
    }
}
