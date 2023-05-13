namespace TaskManagement.Common.Commands
{
    internal interface IDbContext
    {
        IEnumerable<object> Blogs { get; }
    }
}