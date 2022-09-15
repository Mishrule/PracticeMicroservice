using PracticeMicroservice.Web.Models;
using PracticeMicroservice.Web.Services.IServices;

namespace PracticeMicroservice.Web.Services.Implementation
{
  public class ProductService:BaseService, IProductService
  {
    private readonly IHttpClientFactory _clientFactory;
    public ProductService(IHttpClientFactory httpClient, IHttpClientFactory clientFactory) : base(httpClient)
    {
      _clientFactory = clientFactory;
    }

    public async Task<T> GetAllProductAsync<T>()
    {
      return await this.SendAsync<T>(new ApiRequest()
      {
        ApiType = SD.ApiType.GET,
        Url = $"{SD.ProductAPIBase}/api/products",
        AccessToken = ""
      });
    }

    public async Task<T> GetProductByIdAsync<T>(int id)
    {
      return await this.SendAsync<T>(new ApiRequest()
      {
        ApiType = SD.ApiType.GET,
        Url = $"{SD.ProductAPIBase}/api/products/{id}",
        AccessToken = ""
      });
    }

    public async Task<T> CreateProductAsync<T>(ProductDto productDto)
    {
      return await this.SendAsync<T>(new ApiRequest()
      {
        ApiType = SD.ApiType.POST,
        Data = productDto,
        Url = $"{SD.ProductAPIBase}/api/products",
        AccessToken = ""
      });
    }

    public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
    {
      return await this.SendAsync<T>(new ApiRequest()
      {
        ApiType = SD.ApiType.PUT,
        Data = productDto,
        Url = $"{SD.ProductAPIBase}/api/products/{productDto.ProductId}",
        AccessToken = ""
      });
    }

    public async Task<T> DeleteProductAsync<T>(int id)
    {
      return await this.SendAsync<T>(new ApiRequest()
      {
        ApiType = SD.ApiType.DELETE,
        Url = $"{SD.ProductAPIBase}/api/products/{id}",
        AccessToken = ""
      });

    }
  }
}
