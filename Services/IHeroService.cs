using HeroTest.Models;

namespace HeroTest.Services
{
    public interface IHeroService
    {
        IEnumerable<HeroDto> GetAllHeros();
        void AddHero(HeroDto hero);
        public void DeleteHero(int heroId);
    }
}
