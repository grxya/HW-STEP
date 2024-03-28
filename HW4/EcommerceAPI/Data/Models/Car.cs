using System.Text.Json.Serialization;

namespace EcommerceAPI.Data.Models;

public class Car
{
    public int Id { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public int Year { get; set; }

    public int? FuelTypeId { get; set; }

    public int? BodyTypeId { get; set; }

    public int? ColorId { get; set; }

    public string ImageLink { get; set; }

    public virtual BodyType? BodyType { get; set; }

    public virtual Color? Color { get; set; }

    public virtual FuelType? FuelType { get; set; }

    [JsonIgnore]
    public virtual ICollection<ProductList> ProductLists { get; set; } 
}
