using HeroTest.Models;

namespace HeroTest.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly SampleContext _context;

        public BrandService(SampleContext context)
        {
            _context = context;
        }

        public IEnumerable<BrandDto> GetAllBrands()
        {
            var response = new List<BrandDto>();
            var heros = _context.Brands;
            return heros.Select(index => new BrandDto
            {
                Id = index.Id,
                Name = index.Name,
            })
            .ToArray();
        }

    }
}
