using AutoMapper;
using PracticeMicroservice.Services.ProductApi.Models;
using PracticeMicroservice.Services.ProductApi.Models.Dto;

namespace PracticeMicroservice.Services.ProductApi.Mappings
{
  public class MappingConfig
  {
    public static MapperConfiguration RegisterMaps()
    {
      var mappingConfig = new MapperConfiguration(config =>
      {
        config.CreateMap<ProductDto, Product>().ReverseMap();
      });
      return mappingConfig;
    }
  }
}
