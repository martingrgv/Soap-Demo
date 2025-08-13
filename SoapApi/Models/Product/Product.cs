namespace ProductSoapService.Models.Product;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime CreatedOn { get; set; }
}