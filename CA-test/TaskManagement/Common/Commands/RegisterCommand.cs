using TaskManagement.Common.Validators;
using TaskManagement.Database;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;
using TaskManagement.Utilities;


namespace TaskManagement.Common.Commands
{
    public class RegisterCommand : ICommandHandler
    {
        public void Handle()
        {
            UserRepository userRepository = new UserRepository();
            ClassicUserValidator userValidator = new ClassicUserValidator();

            string firstName = userValidator.GetAndValidateFirstName();
            string lastName = userValidator.GetAndValidateLastName();
            string password = userValidator.GetAndValidatePassword();
            string email = userValidator.GetAndValidateEmail();

            User human = new User(firstName, lastName, password, email);
            userRepository.Insert(human);
        }
    }
}
