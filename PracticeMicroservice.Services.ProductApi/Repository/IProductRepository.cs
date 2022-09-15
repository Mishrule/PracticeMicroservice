using PracticeMicroservice.Services.ProductApi.Models.Dto;

namespace PracticeMicroservice.Services.ProductApi.Repository
{
  public interface IProductRepository
  {
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetProductById(int id);
    Task<ProductDto> CreateUpdateProduct(ProductDto product);
    Task<bool> DeleteProduct(int id);
  }
}
