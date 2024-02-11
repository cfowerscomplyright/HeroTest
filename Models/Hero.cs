using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HeroTest.Models;

public partial class Hero : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Alias { get; set; }
    public bool? IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; } = null!;
}

public class HeroDto
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    public int BrandId { get; set; }
    public BrandDto? Brand { get; set; }
}
