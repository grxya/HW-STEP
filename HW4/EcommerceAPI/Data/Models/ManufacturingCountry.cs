using System.Text.Json.Serialization;

namespace EcommerceAPI.Data.Models;

public class ManufacturingCountry
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<Seller> Sellers { get; set; }
}
