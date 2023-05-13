using TaskManagement.Database.Models;

namespace TaskManagement.Common.Commands
{
    internal interface IAuthenticationService
    {
        User GetAuthenticatedUser();
    }
}