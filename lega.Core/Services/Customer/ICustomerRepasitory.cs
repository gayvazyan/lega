using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;

namespace lega.Core
{
    public interface ICustomerRepasitory : IRepositories<Customer> 
    {
    List<Customer> GetPaginatedResult(List<Customer> data, int currentPage, int pageSize);
    int GetCount(List<Customer> data);

    }
}
