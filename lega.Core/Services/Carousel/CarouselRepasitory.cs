using lega.Core.Entities;
using lega.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace lega.Core
{
    public class CarouselRepasitory : Repositories<Carousel>, ICarouselRepasitory
    {
        public CarouselRepasitory(AppDbContext dbContext) : base(dbContext) { }
        public List<Carousel> GetPaginatedResult(List<Carousel> data, int currentPage, int pageSize)
        {
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public int GetCount(List<Carousel> data)
        {
            return data.Count;
        }
    }


}
