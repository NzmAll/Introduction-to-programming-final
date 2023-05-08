using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contants;
using TaskManagement.Database.Models;
using TaskManagement.Database.Repositories.Common;

namespace TaskManagement.Database.Repositories
{
    public class BlogRepository : BaseRepository<Blog, decimal>
    {
        public BlogRepository()
            : base(DataContext.Blogs)
        {
           
        }
    }
}
