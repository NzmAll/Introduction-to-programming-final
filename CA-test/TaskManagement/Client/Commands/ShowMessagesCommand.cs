using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;
using TaskManagement.Services;

namespace TaskManagement.Client.Commands
{
    public class ShowMessagesCommand : ICommandHandler
    {
        public void Handle()
        {
            MessageRepository messageRepository = new MessageRepository();
            List<Message> messages = messageRepository.GetAll(m => m.Receiver == UserService.CurrentUser);

            int currentRowNumber = 1;

            foreach (Message message in messages)
            {
                Console.WriteLine(
                    $"{currentRowNumber}.{message.Sender.GetFullName()} {message.Sender.Email} | {message.Content} | {message.CreatedAt}");

                currentRowNumber++;
            }
        }
    }
}
