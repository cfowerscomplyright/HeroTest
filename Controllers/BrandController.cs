using HeroTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HeroTest.Controllers;
[ApiController]
[Route("[controller]")]
public class BrandController : ControllerBase
{
    private readonly ILogger<BrandController> _logger;
    private readonly SampleContext _sampleContext;

    public BrandController(ILogger<BrandController> logger, SampleContext sampleContext)
    {
        _logger = logger;
        _sampleContext = sampleContext;
    }

    [HttpGet]
    public IEnumerable<BrandDto> Get()
    {
        return _sampleContext.Brands.Select(b => new BrandDto
        {
            Name = b.Name,
            Id = b.Id
        }).ToList();
    }
}

