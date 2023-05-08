using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskManagement.Contants;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories;
using TaskManagement.Services;
using TaskManagement.Utilities;

namespace TaskManagement.Common.Validators
{
    public abstract class BaseUserValidator
    {
        protected StringUtility _utility = new StringUtility();

        #region First name

        public virtual string GetAndValidateFirstName()
        {
            while (true)
            {
                Console.WriteLine(LocalizationService.GetTranslation(TranslationKey.GetAdminName));
                string firstName = Console.ReadLine()!;

                if (IsValidFirstName(firstName))
                    return firstName;

                Console.WriteLine("Some information is not correnct");
            }
        }
        protected virtual bool IsValidFirstName(string firstName)
        {

            int MIN_LENGTH = 3;
            int MAX_LENGTH = 30;

            return IsValidName(firstName, MIN_LENGTH, MAX_LENGTH);
        }

        #endregion

        #region Last name

        public virtual string GetAndValidateLastName()
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
        protected virtual bool IsValidLastName(string lastName)
        {
            int MIN_LENGTH = 5;
            int MAX_LENGTH = 20;

            return IsValidName(lastName, MIN_LENGTH, MAX_LENGTH);
        }

        #endregion

        #region Password

        public virtual string GetAndValidatePassword()
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

        #region Email

        public virtual string GetAndValidateEmail()
        {
            while (true)
            {

                Console.WriteLine("Pls enter email : ");
                string email = Console.ReadLine()!;

                //Pattern for emails where receipecnt can be digit or letter and
                //domain should be code.edu.az
                string pattern = "\"^[A-Z]{1}[a-z0-9]{10,30}@code\\.edu\\.az$\"gm";
                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(email))
                {
                    Console.WriteLine("You email shoud conta, ....");
                    continue;
                }

                if (IsEmailExists(email))
                {
                    Console.WriteLine("Email should be unique");
                    continue;
                }

            }
        }
        public virtual bool IsEmailExists(string email)
        {
            UserRepository userRepository = new UserRepository();
            List<User> users = userRepository.GetAll().Cast<User>().ToList();
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

        protected virtual bool IsValidName(string name, int minLength, int maxLenght)
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
