using HeroTest.Models;
using HeroTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HeroTest.Controllers;
[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{

  private readonly ILogger<HeroesController> _logger;
  private readonly IHeroService _heroService;

  public HeroesController(ILogger<HeroesController> logger, IHeroService service)
  {
    _logger = logger;
    _heroService = service;
  }

  [HttpGet]
  public IEnumerable<Hero> Get() => _heroService.GetHeroes();

  [HttpPost]
  public async Task<Hero> Post(Hero entity) => await _heroService.AddHeroAsync(entity);

  [HttpDelete]
  [Route("{id}")]
  public async void Delete(int id) => await _heroService.DeleteHeroAsync(id);
}