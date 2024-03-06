using HeroTest.Models;
using HeroTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{
    private readonly ILogger<HeroesController> _logger;
    private readonly SampleContext _context;
    private readonly IHeroService _heroService;

    public HeroesController(ILogger<HeroesController> logger, SampleContext context, IHeroService heroService)
    {
        _logger = logger;
        _context = context;
        _heroService = heroService;
    }

    [HttpGet]
    public IEnumerable<HeroDto> Get()
    {
        var heros = _heroService.GetAllHeros();
        return heros;
    }

    [HttpPost]
    public void Post(HeroDto hero)
    {
        _heroService.AddHero(hero);
    }

    [HttpDelete]
    public void Delete(int id)
    {
        _heroService.DeleteHero(id);

    }
}

