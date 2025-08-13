using System.Text.Json;
using ProductService;

IProductService productService = new ProductServiceClient();
var createResult = await productService.CreateAsync(new CreateRequest
{
    Body = new CreateRequestBody(new CreateProductRequest
    {
        Name = "Macbook 16 Pro",
        Price = 5634.21m
    })
});

Console.WriteLine(createResult.Body.CreateResult.Id);

var productsResult = await productService.ProductsAsync(new ProductsRequest(new ProductsRequestBody()));

foreach (var product in productsResult.Body.ProductsResult.Products)
{
    Console.WriteLine(JsonSerializer.Serialize(product));
}

Console.ReadKey();
