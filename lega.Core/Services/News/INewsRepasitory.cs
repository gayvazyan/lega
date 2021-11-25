using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;

namespace lega.Core
{
    public interface INewsRepasitory : IRepositories<News> 
    {
    List<News> GetPaginatedResult(List<News> data, int currentPage, int pageSize);
    int GetCount(List<News> data);

    }
}
