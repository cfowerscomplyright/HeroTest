using HeroTest.Models;

namespace HeroTest.Services.Interfaces
{
  public interface IHeroService
  {
    IEnumerable<Hero> GetHeroes();
    Task<Hero> AddHeroAsync(Hero hero);
    Task DeleteHeroAsync(int id);
  }
}
