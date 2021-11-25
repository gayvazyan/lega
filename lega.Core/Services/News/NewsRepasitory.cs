using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace lega.Core
{
    public class NewsRepasitory : Repositories<News>, INewsRepasitory
    {
        public NewsRepasitory(AppDbContext dbContext) : base(dbContext) { }
        public List<News> GetPaginatedResult(List<News> data, int currentPage, int pageSize)
        {
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public int GetCount(List<News> data)
        {
            return data.Count;
        }
    }


}
