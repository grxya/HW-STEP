using System.Text.Json.Serialization;

namespace EcommerceAPI.Data.Models;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; } 

    public string Password { get; set; }

    public string Email { get; set; }

    [JsonIgnore]
    public virtual ICollection<Seller> Sellers { get; set; }
}
