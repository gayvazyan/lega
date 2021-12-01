using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace lega.Core
{
    public class ContactRepasitory : Repositories<Contact>, IContactRepasitory
    {
        public ContactRepasitory(AppDbContext dbContext) : base(dbContext) { }
        public List<Contact> GetPaginatedResult(List<Contact> data, int currentPage, int pageSize)
        {
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public int GetCount(List<Contact> data)
        {
            return data.Count;
        }
    }


}
