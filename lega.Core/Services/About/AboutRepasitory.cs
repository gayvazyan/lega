using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace lega.Core
{
    public class AboutRepasitory : Repositories<About>, IAboutRepasitory
    {
        public AboutRepasitory(AppDbContext dbContext) : base(dbContext) { }
        public List<About> GetPaginatedResult(List<About> data, int currentPage, int pageSize)
        {
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public int GetCount(List<About> data)
        {
            return data.Count;
        }
    }


}
