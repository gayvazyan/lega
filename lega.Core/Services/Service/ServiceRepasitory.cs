using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace lega.Core
{
    public class ServiceRepasitory : Repositories<Service>, IServiceRepasitory
    {
        public ServiceRepasitory(AppDbContext dbContext) : base(dbContext) { }
        public List<Service> GetPaginatedResult(List<Service> data, int currentPage, int pageSize)
        {
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public int GetCount(List<Service> data)
        {
            return data.Count;
        }
    }


}
