using System.Collections;
using TaskManagement.Common.Commands;
using TaskManagement.Database;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;
using TaskManagement.Infrastructure;
using TaskManagement.Services;

namespace TaskManagement
{
    public class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine()!;
                switch (command)
                {
                    case "/register":
                        CommandRouter.Route<RegisterCommand>();
                        break;
                    case "/login":
                        CommandRouter.Route<LoginCommand>();
                        break;
                    case "/update-language":
                        CommandRouter.Route<UpdateLanguageCommand>();
                        break;
                    case "/exit":
                        Console.WriteLine("Bye-bye");
                        return;
                    default:
                        Console.WriteLine("Invalid command, pls try again");
                        break;
                }
            }
        }
    }
}
