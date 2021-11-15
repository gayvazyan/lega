using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;

namespace lega.Core
{
    public interface ICarouselRepasitory : IRepositories<Carousel> 
    {
    List<Carousel> GetPaginatedResult(List<Carousel> data, int currentPage, int pageSize);
    int GetCount(List<Carousel> data);

    }
}
