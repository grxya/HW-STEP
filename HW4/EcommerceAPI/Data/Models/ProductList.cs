namespace EcommerceAPI.Data.Models;

public class ProductList
{
    public int Id { get; set; }

    public int? CarId { get; set; }

    public int? SellerId { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Seller? Seller { get; set; }
}
