using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Exceptions
{
    public class LocalizationException : ApplicationException
    {
        public LocalizationException(string message)
            : base(message)
        {

        }
    }
}
