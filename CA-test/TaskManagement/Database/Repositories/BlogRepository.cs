using TaskManagement.Database.Models;

namespace TaskManagement.Database.Repositories
{
    public class BlogRepository : JsonFileRepository<Blog>
    {
        public BlogRepository() : base("blogs.json")
        {
        }

        internal List<Blog> GetAll(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        internal Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal void Insert(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
