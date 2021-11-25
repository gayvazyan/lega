using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;

namespace lega.Core
{
    public interface IAboutRepasitory : IRepositories<About> 
    {
    List<About> GetPaginatedResult(List<About> data, int currentPage, int pageSize);
    int GetCount(List<About> data);

    }
}
