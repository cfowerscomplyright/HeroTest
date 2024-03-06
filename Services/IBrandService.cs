using HeroTest.Models;

namespace HeroTest.Services
{
    public interface IBrandService
    {
        IEnumerable<BrandDto> GetAllBrands();
    }
}
