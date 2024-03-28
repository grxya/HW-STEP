using System.Text.Json.Serialization;

namespace EcommerceAPI.Data.Models;

public class Color
{
    public int Id { get; set; }

    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Car> Cars { get; set; } 
}
