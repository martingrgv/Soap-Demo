using Microsoft.Extensions.Caching.Memory;
using ProductSoapService.Contracts.Soap;
using ProductSoapService.Product.CreateProduct;
using ProductSoapService.Product.GetProducts;

namespace ProductSoapService.Product;

public class ProductService(IMemoryCache cache) : IProductService
{
    public CreateProductResult Create(CreateProductRequest request)
    {
        var productId = Guid.NewGuid();
        var product = new Models.Product.Product
        {
            Id = productId,
            Name = request.Name,
            Price = request.Price,
            CreatedOn = DateTime.Now
        };

        var products = cache.Get<List<Models.Product.Product>>("products");
        products.Add(product);

        return new CreateProductResult
        {
            Id = productId
        };
    }

    public GetProductsResult Products()
    {
        return new GetProductsResult
        {
            Products = cache.Get<List<Models.Product.Product>>("products")
        };
    }
}