using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;

namespace TaskManagement.Infrastructure
{
    public static class CommandRouter
    {
        public static void Route<TCommand>()
            where TCommand : ICommandHandler
        {
            TCommand commandHandler = Activator.CreateInstance<TCommand>();
            commandHandler.Handle();
        }

    }
}
