using TaskManagement.Contants;
using TaskManagement.Database.Models.Common;

namespace TaskManagement.Database.Models
{
    //entity
    public class User : BaseEntity<int>
    {
        public static int IdCounter { get; private set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; } 
        public bool IsBanned { get; set; }
        public string PhoneNumber { get; set; }
        public object FirstName { get; internal set; }

        public User(string name, string lastName, string password, string email, UserRole role = UserRole.Member)
            : this(name, lastName, password, email, DateTime.Now, role) { }

        public User(string name, string lastName, string password, string email, DateTime createdAt, UserRole role)
        { 
            Id = ++IdCounter;
            Name = name;
            LastName = lastName;
            Password = password;
            Email = email;
            Role = role;
            CreatedAt = createdAt;
        }

        public string GetShortInfo()
        {
            return $"Id : {Id}, Full name : {Name} {LastName}, Email : {Email}, Is admin : {GetIsAdminInfo()}";
        }

        public string GetIsAdminInfo()
        {
            return Role == UserRole.Admin ? "Yes" : "No";
        }

        public string GetFullName()
        {
            return $"{Name} {LastName}";
        }
    }
}