using System.Text.Json.Serialization;

namespace EcommerceAPI.Data.Models;

public class Seller
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string CompanyName { get; set; }

    public string ContactNumber { get; set; }

    public int? ManufacturingCountryId { get; set; }

    public int Rating { get; set; }

    public virtual ManufacturingCountry? ManufacturingCountry { get; set; }

    [JsonIgnore]
    public virtual ICollection<ProductList> ProductLists { get; set; }

    public virtual User? User { get; set; }
}
