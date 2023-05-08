using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories.Common;

namespace TaskManagement.Database.Repositories
{
    public class MessageRepository : BaseRepository<Message, int>
    {
        public MessageRepository() 
            : base(DataContext.Messages)
        {

        }
    }
}
