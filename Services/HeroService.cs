using HeroTest.Models;
using HeroTest.Services.Interfaces;

namespace HeroTest.Services
{
  public class HeroService : IHeroService
  {
    private readonly SampleContext _sampleContext;

    public HeroService(SampleContext sampleContext)
    {
      _sampleContext = sampleContext;
    }

    public IEnumerable<Hero> GetHeroes() => _sampleContext.Heroes.Where(h => h.IsActive.HasValue ? h.IsActive.Value : false);

    public async Task<Hero> AddHeroAsync(Hero hero)
    {
      var heroEntry = await _sampleContext.Heroes.AddAsync(hero);
      _ = await _sampleContext.SaveChangesAsync();
      
      await heroEntry.ReloadAsync();

      return heroEntry.Entity ?? new();
    }

    public async Task DeleteHeroAsync(int id)
    {
      var hero = _sampleContext.Heroes.Where(h => h.Id == id).First();

      if (hero != null)
      {
        hero.IsActive = false;

        _sampleContext.Entry(hero);

        _ = await _sampleContext.SaveChangesAsync();
      }
    }
  }
}
