using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace lega.Core
{
    public class PricingRepasitory : Repositories<Pricing>, IPricingRepasitory
    {
        public PricingRepasitory(AppDbContext dbContext) : base(dbContext) { }
        public List<Pricing> GetPaginatedResult(List<Pricing> data, int currentPage, int pageSize)
        {
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public int GetCount(List<Pricing> data)
        {
            return data.Count;
        }
    }


}
