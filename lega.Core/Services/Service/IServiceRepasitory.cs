using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;

namespace lega.Core
{
    public interface IServiceRepasitory : IRepositories<Service> 
    {
    List<Service> GetPaginatedResult(List<Service> data, int currentPage, int pageSize);
    int GetCount(List<Service> data);

    }
}
