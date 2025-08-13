using Microsoft.Extensions.Caching.Memory;
using ProductSoapService.Contracts.Soap;
using ProductSoapService.Models.Product;
using ProductSoapService.Product;
using SoapCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSoapCore();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IProductService>("/Product.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

var memory = app.Services.GetRequiredService<IMemoryCache>();
AddProducts(memory);

app.Run();


void AddProducts(IMemoryCache cache)
{
    cache.CreateEntry("products");
    cache.Set("products", new List<Product>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Macbook 13 Air",
            Price = 1456.42m
        },
        new()
        {
            Id = Guid.NewGuid(),
            Name = "Macbook 15 Air",
            Price = 2350.39m
        }
    });
}