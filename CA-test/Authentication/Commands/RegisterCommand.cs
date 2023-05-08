using Authentication.Database;
using Authentication.Database.Models;
using Authentication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Commands
{
    public class RegisterCommand
    {
        private StringUtility _utility = new StringUtility();

        public void Handle(DataContext database)
        {
            string firstName = GetAndValidateFirstName();
            string lastName = GetAndValidateLastName();
            string password = GetAndValidatePassword();
            string email = GetAndValidateEmail(database.Users);

            User human = new User(firstName, lastName, password, email);

            database.Users.Add(human);
        }

        #region First name

        private string GetAndValidateFirstName()
        {
            while (true)
            {
                Console.WriteLine("Pls enter first name : ");
                string firstName = Console.ReadLine()!;

                if (IsValidFirstName(firstName))
                    return firstName;

                Console.WriteLine("Some information is not correnct");
            }
        }
        private bool IsValidFirstName(string firstName)
        {
            int MIN_LENGTH = 3;
            int MAX_LENGTH = 30;

            return IsValidName(firstName, MIN_LENGTH, MAX_LENGTH);
        }

        #endregion

        #region Last name

        private string GetAndValidateLastName()
        {
            while (true)
            {
                Console.WriteLine("Pls enter last name : ");
                string lastName = Console.ReadLine()!;

                if (IsValidLastName(lastName))
                    return lastName;

                Console.WriteLine("Some information is not correnct");
            }
        }
        private bool IsValidLastName(string lastName)
        {
            int MIN_LENGTH = 5;
            int MAX_LENGTH = 20;

            return IsValidName(lastName, MIN_LENGTH, MAX_LENGTH);
        }

        #endregion

        #region Password

        private string GetAndValidatePassword()
        {
            while (true)
            {
                Console.WriteLine("Pls enter password : ");
                string password = Console.ReadLine()!;

                Console.WriteLine("Pls enter confirm password : ");
                string confirmPassword = Console.ReadLine()!;

                if (password == confirmPassword)
                    return password;

                Console.WriteLine("Some information is not correnct");
            }
        }

        #endregion

        #region Password

        private string GetAndValidateEmail(List<User> users)
        {
            char AT_SIGN = '@';

            while (true)
            {

                Console.WriteLine("Pls enter email : ");
                string email = Console.ReadLine()!;
                //Way 1
                //if (_utility.Contains(email, AT_SIGN) && !IsEmailExists(users, email))
                //    return email;

                //Way2
                //bool isValidFormat = false;
                //bool isUnique = false;

                //if (_utility.Contains(email, AT_SIGN))
                //    isValidFormat = true;
                //else
                //{
                //    isValidFormat = false;
                //    Console.WriteLine("Ensure that your email contains @ characheter");
                //}

                //if (!IsEmailExists(users, email))
                //    isUnique = true;
                //else
                //{
                //    isUnique = false;
                //    Console.WriteLine("Your email is already used in system, pls try another email");
                //}

                //if (isValidFormat && isUnique)
                //    return email;

                //Way 3
                //if (_utility.Contains(email, AT_SIGN))
                //{
                //    if (!IsEmailExists(users, email))
                //        return email;
                //    else
                //        Console.WriteLine("Your email is already used in system, pls try another email");
                //}
                //else
                //    Console.WriteLine("Ensure that your email contains @ characheter");

            }
        }
        private bool IsEmailExists(List<User> users, string email)
        {
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Common

        private bool IsValidName(string name, int minLength, int maxLenght)
        {
            if (!_utility.IsLengthBetween(name, minLength, maxLenght))
            {
                return false;
            }

            char firstLetter = name[0];

            if (!_utility.IsUpperLetter(firstLetter))
            {
                return false;
            }

            for (int i = 1; i < name.Length; i++)
            {
                if (_utility.IsUpperLetter(name[i]))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}
