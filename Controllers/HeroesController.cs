using HeroTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HeroTest.Controllers;
[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{
    private readonly ILogger<HeroesController> _logger;
    private readonly SampleContext _sampleContext;

    public HeroesController(ILogger<HeroesController> logger, SampleContext sampleContext)
    {
        _logger = logger;
        _sampleContext = sampleContext;
    }

    [HttpGet]
    public IEnumerable<HeroDto> Get()
    {
        var heroes = _sampleContext.Heroes.Where(h => h.IsActive == true).Include("Brand").Select(h => new HeroDto
        {
            Id = h.Id,
            Alias = h.Alias ?? "",
            Name = h.Name,
            BrandId = h.BrandId,
            Brand = new BrandDto
            {
                Name = h.Brand.Name,
                Id = h.BrandId
            }
        }).ToList();
        return heroes;
    }


    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult Delete(int id)
    {
        var hero = _sampleContext.Heroes.Find(id);
        
        if (hero == null)
        {
            return NotFound();
        }

        hero.IsActive = false;
        _sampleContext.Heroes.Update(hero);
        _sampleContext.SaveChanges();
        return Ok();
    }

    [HttpPost]
    public IActionResult Add([FromBody] HeroDto dto)
    {
        var hero = new Hero
        {
            Name = dto.Name,
            Alias = dto.Alias,
            BrandId = dto.BrandId,
            IsActive = true
        };

        _sampleContext.Heroes.Add(hero);
        _sampleContext.SaveChanges();
        return Ok(hero.Id);
    }
}

