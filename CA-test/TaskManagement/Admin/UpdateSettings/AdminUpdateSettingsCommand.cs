using TaskManagement.Admin.UpdateSettings.Validators;
using TaskManagement.Common.Commands;
using TaskManagement.Common.Validators;
using TaskManagement.Services;

namespace TaskManagement.Admin.UpdateSettings
{
    public class AdminUpdateSettingsCommand : BaseUpdateSettingsCommand
    {
        public AdminUpdateSettingsCommand() 
            : base(new AdminUpdateSettingsValidator())
        {

        }

        public override void Handle()
        {
           
            UserService.CurrentUser.PhoneNumber = GetAndValidatePhoneNnumber();
        }

        private string GetAndValidatePhoneNnumber()
        {
            return string.Empty;
        }
    }
}
