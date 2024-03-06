namespace HeroTest.Models;

public partial class BrandDto
{
    public int Id { get; set; } = 1;
    public string Name { get; set; } = null!;
    public bool? IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}
