using HeroTest.Controllers;
using HeroTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroTest.Services.Implementations
{
    public class HeroService : IHeroService
    {
        private readonly SampleContext _context;

        public HeroService(SampleContext context)
        {
            _context = context;
        }

        public IEnumerable<HeroDto> GetAllHeros()
        {
            var response = new List<HeroDto>();
            var heros = _context.Heroes.Include(t => t.Brand);
           return heros.Select(index => new HeroDto
            {
                Id = index.Id,
                Name = index.Name,
                Alias = index.Alias,
                IsActive = index.IsActive,
                CreatedOn = index.CreatedOn,
                UpdatedOn = index.UpdatedOn,
                BrandId = index.BrandId,
                Brand = new BrandDto()
                {
                    Name = index.Brand.Name,
                    Id = index.Brand.Id,
                }
            })
            .ToArray();
        }

        public void AddHero(HeroDto hero)
        {
            Hero heroMapped = new Hero
            {
                Id = 0,
                Name = hero.Name,
                Alias = hero.Alias,
                IsActive = hero.IsActive,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                BrandId = hero.BrandId,
            };

            _context.Heroes.Add(heroMapped);
            _context.SaveChanges();
        }

        public void DeleteHero(int heroId)
        {
            var hero = _context.Heroes.Where(h => h.Id == heroId).FirstOrDefault();
            if (hero != null)
            {
                hero.IsActive = !hero.IsActive;
                _context.Heroes.Update(hero);
                _context.SaveChanges();
            }
        }
    }
}
