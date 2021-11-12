using lega.Core.Entities;
using lega.Core.Repository;

namespace lega.Core
{
    public class UserRepasitory : Repositories<Users>, IUserRepasitory
    {
        public UserRepasitory(AppDbContext dbContext) : base(dbContext) { }
    }
}
