using lega.Core.Entities;
using lega.Core.Repository;

namespace lega.Core
{
    public class CarouselRepasitory : Repositories<Carousel>, ICarouselRepasitory
    {
        public CarouselRepasitory(AppDbContext dbContext) : base(dbContext) { }
    }
}
