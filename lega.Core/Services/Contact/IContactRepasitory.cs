using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;

namespace lega.Core
{
    public interface IContactRepasitory : IRepositories<Contact> 
    {
    List<Contact> GetPaginatedResult(List<Contact> data, int currentPage, int pageSize);
    int GetCount(List<Contact> data);

    }
}
