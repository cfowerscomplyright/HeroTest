namespace HeroTest.Models;

public partial class Brand : IEntity
{
    public Brand()
    {
        Heroes = new HashSet<Hero>();
    }

    public int Id { get; set; } = 1;
    public string Name { get; set; } = null!;
    public bool? IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public virtual ICollection<Hero> Heroes { get; set; }
}

public class BrandDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

