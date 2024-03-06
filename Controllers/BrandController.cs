using HeroTest.Models;
using HeroTest.Services;
using HeroTest.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [Route("getBrands")]
        public IEnumerable<BrandDto> GetBrands()
        {
            var brands = _brandService.GetAllBrands();
            return brands;
        }
    }
}
