using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Common.Commands
{
    public interface ILocalizable
    {
        Dictionary<string, string> Translations { get; set; }


    }

}
