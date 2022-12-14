using AutoMapper;
using PracticeMicroservice.Services.ShoppingCartAPI.Models;
using PracticeMicroservice.Services.ShoppingCartAPI.Models.Dto;

namespace PracticeMicroservice.Services.ShoppingCartAPI.Mappings
{
  public class MappingConfig
  {
    public static MapperConfiguration RegisterMaps()
    {
      var mappingConfig = new MapperConfiguration(config =>
      {
        config.CreateMap<ProductDto, Product>().ReverseMap();
        config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
        config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
        config.CreateMap<Cart, CartDto>().ReverseMap();

      });

      return mappingConfig;
    }

  }
}
