namespace ProductSoapService.Product.CreateProduct;

public record CreateProductRequest
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; } 
}