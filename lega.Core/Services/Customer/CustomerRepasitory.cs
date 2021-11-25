using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace lega.Core
{
    public class CustomerRepasitory : Repositories<Customer>, ICustomerRepasitory
    {
        public CustomerRepasitory(AppDbContext dbContext) : base(dbContext) { }
        public List<Customer> GetPaginatedResult(List<Customer> data, int currentPage, int pageSize)
        {
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public int GetCount(List<Customer> data)
        {
            return data.Count;
        }
    }


}
