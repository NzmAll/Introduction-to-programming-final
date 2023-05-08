using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;
using TaskManagement.Services;

namespace TaskManagement.Admin.MessageManagement
{
    public class SendMessageCommand : ICommandHandler
    {
        public void Handle()
        {
            UserRepository userRepository = new UserRepository();
            MessageRepository messageRepository = new MessageRepository();

            string receiverEmail = Console.ReadLine()!;
            User receiver = userRepository.GetUserOrDefaultByEmail(receiverEmail);

            string content = Console.ReadLine()!; //+validations

            if (receiver == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            Message message = new Message(content, UserService.CurrentUser, receiver);
            messageRepository.Insert(message);
        }
    }
}
