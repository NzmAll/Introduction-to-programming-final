using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contants;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;

namespace TaskManagement.Services
{
    public class MessageService
    {
        private MessageRepository _messageRepository;

        public MessageService()
        {
            _messageRepository = new MessageRepository();
        }

        public void SenApprovedMessage(Blog blog)
        {
            string approvedMessage = PrepareBlogMessage(MessageTemplate.BLOG_APPROVED_TEMPLATE, blog);
            SendMessage(approvedMessage, blog.Owner);
        }

        public void SendRejectedMessage(Blog blog)
        {
            string rejectedMessage = PrepareBlogMessage(MessageTemplate.BLOG_REJECTED_TEMPLATE, blog);
            SendMessage(rejectedMessage, blog.Owner);
        }

        private string PrepareBlogMessage(string blogMessageTemplate, Blog blog)
        {
            return blogMessageTemplate
              .Replace(MessageTemplateKeyword.FIRST_NAME, blog.Owner.Name)
              .Replace(MessageTemplateKeyword.LAST_NAME, blog.Owner.LastName)
              .Replace(MessageTemplateKeyword.BLOG_TITLE, blog.Title);
        }

        public void SendMessage(string message, User sender, User receiver)
        {
            Message messageRecord = new Message(message, sender, receiver);
            _messageRepository.Insert(messageRecord);
        }

        /// <summary>
        /// Sender will be current logged user
        /// </summary>
        public void SendMessage(string message, User receiver)
        {
            SendMessage(message, UserService.CurrentUser, receiver);
        }
    }
}
