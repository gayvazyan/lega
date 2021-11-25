using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;

namespace lega.Core
{
    public interface IPricingRepasitory : IRepositories<Pricing> 
    {
    List<Pricing> GetPaginatedResult(List<Pricing> data, int currentPage, int pageSize);
    int GetCount(List<Pricing> data);

    }
}
