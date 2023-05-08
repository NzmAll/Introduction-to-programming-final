using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Contants
{
    public enum UserRole : long
    {
        Member =  1, 
        Admin = 2, 
        Moderator = 4, 
        SMM = 8
    }
}
