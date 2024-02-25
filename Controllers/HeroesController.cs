using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeroTest.Models;

[Route("api/[controller]")]
[ApiController]
public class HeroesController : ControllerBase
{
    private readonly SampleContext _context;

    public HeroesController(SampleContext context)
    {
        _context = context;
    }

    // GET: api/Heroes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hero>>> GetHeroes()
    {
        var heroes = await _context.Heroes
            .Include(h => h.Brand)
            .Select(h => new Hero
            {
                Id = h.Id,
                Name = h.Name,
                Alias = h.Alias,
                IsActive = h.IsActive,
                CreatedOn = h.CreatedOn,
                UpdatedOn = h.UpdatedOn,
                Brand = h.Brand
            })
            .ToListAsync();

        return Ok(heroes);
    }

    // GET: api/Heroes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Hero>> GetHero(int id)
    {
        var hero = await _context.Heroes
            .Include(h => h.Brand)
            .FirstOrDefaultAsync(h => h.Id == id);

        if (hero == null)
        {
            return NotFound();
        }

        return Ok(hero);
    }

    // POST: api/Heroes
    [HttpPost]
    public async Task<ActionResult<int>> AddHero(Hero model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid model");
        }

        var brand = await _context.Brands.FindAsync(model.BrandId);

        if (brand == null)
        {
            return BadRequest("Invalid Brand");
        }

        var hero = new Hero
        {
            Name = model.Name,
            Alias = model.Alias,
            Brand = brand,
            IsActive = true,
            CreatedOn = DateTime.UtcNow,
            UpdatedOn = DateTime.UtcNow
        };

        _context.Heroes.Add(hero);
        await _context.SaveChangesAsync();

        return Ok(hero.Id);
    }

    // PUT: api/Heroes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHero(int id, Hero model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        var hero = await _context.Heroes.FindAsync(id);

        if (hero == null)
        {
            return NotFound();
        }

        hero.Name = model.Name;
        hero.Alias = model.Alias;
        hero.UpdatedOn = DateTime.UtcNow;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HeroExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Heroes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHero(int id)
    {
        var hero = await _context.Heroes.FindAsync(id);

        if (hero == null)
        {
            return NotFound();
        }

        hero.IsActive = false;
        hero.UpdatedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HeroExists(int id)
    {
        return _context.Heroes.Any(e => e.Id == id);
    }
}
