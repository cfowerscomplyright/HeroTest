using System.Text.Json;
using System.Text.Json.Serialization;

namespace HeroTest.Models;


public partial class Hero
{
  [JsonPropertyName("id")]
  public int Id { get; set; }
  [JsonPropertyName("name")]
  public string Name { get; set; } = null!;
  [JsonPropertyName("alias")]
  public string? Alias { get; set; }
  [JsonPropertyName("isActive")]
  public bool? IsActive { get; set; }
  [JsonPropertyName("createdOn")]
  public DateTime CreatedOn { get; set; }
  [JsonPropertyName("updatedOn")]
  public DateTime UpdatedOn { get; set; }
  [JsonPropertyName("brandId")]
  public int BrandId { get; set; }
  [JsonIgnore]
  public virtual Brand Brand { get; set; } = null!;
}
