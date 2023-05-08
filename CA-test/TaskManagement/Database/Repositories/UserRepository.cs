using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories.Common;

namespace TaskManagement.Database.Repositories
{
    //Geneerc, asdasd 
    public class UserRepository : BaseRepository<User, int>
    {
        public UserRepository()
            : base(DataContext.Users) { }

        public User GetUserOrDefaultByEmail(string email)
        {
            return GetBy(u => u.Email == email)!;
        }
    }
}
