using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Common.Validators;
using TaskManagement.Contants;
using TaskManagement.Database;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;

namespace TaskManagement.Admin.UserManagement
{
    public class AddUserCommand : ICommandHandler
    {
        public void Handle()
        {
            ClassicUserValidator userValidator = new ClassicUserValidator();
            UserRepository userRepository = new UserRepository();

            string firstName = userValidator.GetAndValidateFirstName();
            string lastName = userValidator.GetAndValidateLastName();
            string password = userValidator.GetAndValidatePassword();
            string email = userValidator.GetAndValidateEmail();

            User human = new User(firstName, lastName, password, email, UserRole.Member);

            userRepository.Insert(human);
        }
    }
}
