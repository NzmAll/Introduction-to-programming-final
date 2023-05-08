using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Validators;

namespace TaskManagement.Admin.UpdateSettings.Validators
{
    public class AdminUpdateSettingsValidator : BaseUserValidator
    {
        protected override bool IsValidFirstName(string firstName)
        {
            return _utility.IsLengthBetween(firstName, 2, 30);
        }

    }
}
