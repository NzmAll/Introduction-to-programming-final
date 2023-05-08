using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Common.Validators;
using TaskManagement.Services;

namespace TaskManagement.Client.Commands
{
    public class UpdateSettingsCommand : BaseUpdateSettingsCommand
    {
        public UpdateSettingsCommand() 
            : base(new ClassicUserValidator())
        {

        }
    }
}
