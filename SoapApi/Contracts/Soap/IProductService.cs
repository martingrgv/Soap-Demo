using System.ServiceModel;
using ProductSoapService.Product.CreateProduct;
using ProductSoapService.Product.GetProducts;

namespace ProductSoapService.Contracts.Soap;

[ServiceContract]
public interface IProductService
{
    [OperationContract]
    CreateProductResult Create(CreateProductRequest request);

    [OperationContract]
    GetProductsResult Products();
}